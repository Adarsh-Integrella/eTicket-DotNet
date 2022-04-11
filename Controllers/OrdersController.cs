using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using eTickets.Models;
using eTickets.Data;
using Microsoft.EntityFrameworkCore;
using eTickets.Services;
using eTickets.Data.Cart;
using System.Security.Claims;

namespace eTickets.Controllers;

public class OrdersController : Controller
{
    private readonly IMoviesService _moviesService;
    private readonly ShoppingCart _shoppingCart;
    private readonly IOrdersService _orderService;
    public OrdersController(IMoviesService moviesService, ShoppingCart shoppingCart, IOrdersService orderService)
    {
        _moviesService = moviesService;
        _shoppingCart = shoppingCart;
        _orderService = orderService;
    }

    public async Task<IActionResult> Index()
    {
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        string userRole = User.FindFirstValue(ClaimTypes.Role);
        var orders = await _orderService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
        return View(orders);
    }

    public IActionResult ShoppingCart()
    {
        var items = _shoppingCart.GetShoppingCartItems();
        _shoppingCart.ShoppingCartItems = items;
        var response = new ShoppingCartVM()
        {
            ShoppingCart = _shoppingCart,
            ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
        };
        return View(response);
    }
    public async Task<IActionResult> AddShoppingCart(int id)
    {
        var item = await _moviesService.GetMovieByIdAsync(id);
        if (item != null)
        {
            _shoppingCart.AddItemToCart(item);
        }
        return RedirectToAction(nameof(ShoppingCart));
    }
    public async Task<IActionResult> RemoveItemFromCart(int id)
    {
        var item = await _moviesService.GetMovieByIdAsync(id);
        if (item != null)
        {
            _shoppingCart.RemoveItemFromCart(item);
        }
        return RedirectToAction(nameof(ShoppingCart));
    }
    public async Task<IActionResult> CompleteOrder()
    {
        var items = _shoppingCart.GetShoppingCartItems();
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

        await _orderService.StoreOrderAsync(items, userId, userEmailAddress);
        await _shoppingCart.ClearShoppingCartAsync();
        return View("OrderCompleted");
    }
}

using eTickets.Base;
using eTickets.Data;
using eTickets.Models;

namespace eTickets.Services
{
    public interface IOrdersService
    {
        public Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);

    }
}
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using eTickets.Models;
using eTickets.Data;
using eTickets.Services;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers;

public class MoviesController : Controller
{
    private readonly IMoviesService _service;
    public MoviesController(IMoviesService service)
    {
        _service=service;
    }

   public async Task<IActionResult> Index()
    {
        var data = await _service.GetAllAsync(n=> n.Cinema);
        return View(data);
    }
    public async Task<IActionResult> Details(int id)
    {
        var data = await _service.GetMovieByIdAsync(id);
        return View(data);
    }
}
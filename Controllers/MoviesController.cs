using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using eTickets.Models;
using eTickets.Data;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers;

public class MoviesController : Controller
{
    private readonly AppDbContext _context;
    public MoviesController(AppDbContext context)
    {
        _context = context;
    }
   public async Task<IActionResult> Index()
    {
        var data = await _context.Movies.Include(n => n.Cinema).ToListAsync();
        return View(data);
    }
}
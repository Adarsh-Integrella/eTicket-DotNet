using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using eTickets.Models;
using eTickets.Data;
using eTickets.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
   public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(n => n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                // var filteredResultNew = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResult);
            }

            return View("Index", allMovies);
        }
    public async Task<IActionResult> Details(int id)
    {
        var data = await _service.GetMovieByIdAsync(id);
        return View(data);
    }
    
    public async Task<IActionResult> Create()
    {
        var MovieDropDownData = await _service.GetNewMovieDropDownValues();
        ViewBag.Cinemas = new SelectList(MovieDropDownData.Cinemas, "Id", "Name");
        ViewBag.Producers = new SelectList(MovieDropDownData.Producers, "Id", "FullName");
        ViewBag.Actors = new SelectList(MovieDropDownData.Actors, "Id", "FullName"); 
        return View();

    }
    [HttpPost]
    public async Task<IActionResult> Create(NewMovieVM movie)
    {
        if(!ModelState.IsValid)
        {
            return View(movie);
        }
        await _service.AddNewMovieAsync(movie);
        return RedirectToAction(nameof(Index));
    }

//Get: Movies/Edit/id
public async Task<IActionResult> Edit(int id)
    {
        var movieDetails = await _service.GetMovieByIdAsync(id);
        if(movieDetails==null) return View("Not found");

        var response = new NewMovieVM()
        {
            Id = movieDetails.Id,
            Name = movieDetails.Name,
            Description = movieDetails.Description,
            Price = movieDetails.Price,
            ImageURL = movieDetails.ImageURL,
            MovieCategory = movieDetails.MovieCategory,
            CinemaId = movieDetails.CinemaId,
            ProducerId = movieDetails.ProducerId,
            ActorIds = movieDetails.Actor_Movies.Select(n => n.ActorId).ToList(),
            StartDate = movieDetails.StartDate,
            EndDate = movieDetails.EndDate
        };

        var MovieDropDownData = await _service.GetNewMovieDropDownValues();
        ViewBag.Cinemas = new SelectList(MovieDropDownData.Cinemas, "Id", "Name");
        ViewBag.Producers = new SelectList(MovieDropDownData.Producers, "Id", "FullName");
        ViewBag.Actors = new SelectList(MovieDropDownData.Actors, "Id", "FullName"); 
        return View(response);

    }
    [HttpPost]
    public async Task<IActionResult> Edit(int id, NewMovieVM movie)
    {
        if(id != movie.Id) return View("Not found");
        if(!ModelState.IsValid)
        {
            return View(movie);
        }
        await _service.UpdateMovieAsync(movie);
        return RedirectToAction(nameof(Index));
    }


}
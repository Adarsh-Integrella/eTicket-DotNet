using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using eTickets.Models;
using eTickets.Data;
using Microsoft.EntityFrameworkCore;
using eTickets.Services;

namespace eTickets.Controllers;

public class CinemasController : Controller
{
    private readonly ICinemasService _service;
    public CinemasController(ICinemasService service)
    {
        _service = service;
    }
   public async Task<IActionResult> Index()
    {
        var data = await _service.GetAllAsync();
        return View(data);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost, ActionName("Create")]
    public async Task<IActionResult> Create([Bind("Name, Logo, Description")]Cinema cinema)
    {
        // if(!ModelState.IsValid){
        //     return View(Cinema);
        // }
        await _service.AddAsync(cinema);
        return RedirectToAction(nameof(Index));
    }
     public async Task<IActionResult> Details(int id)
    {
        var CinemaDetails = await _service.GetByIdAsync(id); 
        if(CinemaDetails==null){
            return View("Empty");
        }
        return View(CinemaDetails);
    }
public async Task<IActionResult> Edit(int id)
    {
        var CinemaDetails = await _service.GetByIdAsync(id); 
        if(CinemaDetails==null){
            return View("Not found");
        }
        return View(CinemaDetails);
    }
    [HttpPost, ActionName("Edit")]
    public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Logo, Description")]Cinema cinema)
    {
        // if(!ModelState.IsValid){
        //     return View(Cinema);
        // }
        await _service.UpdateAsync(id, cinema);
        return RedirectToAction(nameof(Index));
    }
   //Cinemas/delete
   public async Task<IActionResult> Delete(int id)
    {
        var CinemaDetails = await _service.GetByIdAsync(id); 
        if(CinemaDetails==null){
            return View("Not found");
        }
        return View(CinemaDetails);
    }
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        var CinemaDetails = await _service.GetByIdAsync(id); 
        if(CinemaDetails==null){
            return View("Not found");
        }
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
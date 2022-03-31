using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using eTickets.Models;
using eTickets.Data;
using Microsoft.EntityFrameworkCore;
using eTickets.Services;

namespace eTickets.Controllers;

public class ActorsController : Controller
{
    private readonly IActorsService _service;
    public ActorsController(IActorsService service)
    {
        _service = service;
    }
   public async Task<IActionResult> Index()
    {
        var data = await _service.GetAllAsync();
        return View(data);
    }
    //Get: Actors/Create
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost, ActionName("Create")]
    public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL, Bio")]Actor actor)
    {
        // if(!ModelState.IsValid){
        //     return View(actor);
        // }
        await _service.AddAsync(actor);
        return RedirectToAction(nameof(Index));
    }
     public async Task<IActionResult> Details(int id)
    {
        var actorDetails = await _service.GetByIdAsync(id); 
        if(actorDetails==null){
            return View("Empty");
        }
        return View(actorDetails);
    }
public async Task<IActionResult> Edit(int id)
    {
        var actorDetails = await _service.GetByIdAsync(id); 
        if(actorDetails==null){
            return View("Not found");
        }
        return View(actorDetails);
    }
    [HttpPost, ActionName("Edit")]
    public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, ProfilePictureURL, Bio")]Actor actor)
    {
        // if(!ModelState.IsValid){
        //     return View(actor);
        // }
        await _service.UpdateAsync(id, actor);
        return RedirectToAction(nameof(Index));
    }
   //Actors/delete
   public async Task<IActionResult> Delete(int id)
    {
        var actorDetails = await _service.GetByIdAsync(id); 
        if(actorDetails==null){
            return View("Not found");
        }
        return View(actorDetails);
    }
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        var actorDetails = await _service.GetByIdAsync(id); 
        if(actorDetails==null){
            return View("Not found");
        }
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
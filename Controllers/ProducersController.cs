using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using eTickets.Models;
using eTickets.Data;
using Microsoft.EntityFrameworkCore;
using eTickets.Services;

namespace eTickets.Controllers;

public class ProducersController : Controller
{
    private readonly IProducersService _service;
    public ProducersController(IProducersService service)
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
    public async Task<IActionResult> Create([Bind("FullName, ProfilePictureURL, Bio")]Producer Producer)
    {
        // if(!ModelState.IsValid){
        //     return View(Producer);
        // }
        await _service.AddAsync(Producer);
        return RedirectToAction(nameof(Index));
    }
     public async Task<IActionResult> Details(int id)
    {
        var ProducerDetails = await _service.GetByIdAsync(id); 
        if(ProducerDetails==null){
            return View("Empty");
        }
        return View(ProducerDetails);
    }
public async Task<IActionResult> Edit(int id)
    {
        var ProducerDetails = await _service.GetByIdAsync(id); 
        if(ProducerDetails==null){
            return View("Not found");
        }
        return View(ProducerDetails);
    }
    [HttpPost, ActionName("Edit")]
    public async Task<IActionResult> Edit(int id, [Bind("Id, FullName, ProfilePictureURL, Bio")]Producer Producer)
    {
        // if(!ModelState.IsValid){
        //     return View(Producer);
        // }
        await _service.UpdateAsync(id, Producer);
        return RedirectToAction(nameof(Index));
    }
   //Producers/delete
   public async Task<IActionResult> Delete(int id)
    {
        var ProducerDetails = await _service.GetByIdAsync(id); 
        if(ProducerDetails==null){
            return View("Not found");
        }
        return View(ProducerDetails);
    }
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        var ProducerDetails = await _service.GetByIdAsync(id); 
        if(ProducerDetails==null){
            return View("Not found");
        }
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
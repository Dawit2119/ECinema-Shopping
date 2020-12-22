using ECinema.Data;
using ECinema.Data.Services;
using ECinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECinema.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorsService _service;
        public ActorController(IActorsService service)
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Actor actor)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(actor);
                return RedirectToAction("Index");
            }
            return View(actor);
        }
        public async Task<IActionResult> GetDetails(int id)
        {
            var actor = await _service.GetByIdAsync(id);
            if(actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }
        public async Task<IActionResult> Update(int id)
        {
            var actor = await _service.GetByIdAsync(id);
            if (actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Update(int id,Actor actor)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id, actor);
                return RedirectToAction("Index");
            }
            else
            {
                return View(actor);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            var actor = await _service.GetByIdAsync(id);
            if (actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteActor(int id)
        {
            var actor = await _service.GetByIdAsync(id);
            if (actor == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}

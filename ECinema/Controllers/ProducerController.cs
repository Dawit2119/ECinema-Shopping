using ECinema.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECinema.Controllers
{
    public class ProducerController : Controller
    {
        public  readonly AppDbContext _context;
        public ProducerController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var producers = await _context.Producers.ToListAsync();
            return View(producers);
        }
    }
}

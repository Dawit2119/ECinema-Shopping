using ECinema.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ECinema.Controllers
{
    public class MovieController : Controller
    {
        private readonly AppDbContext _context;
        public MovieController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.Movies.Include(m=>m.Cinema).OrderByDescending(m=>m.EndDate).ToListAsync();
            return View(data);
        }
    }
}

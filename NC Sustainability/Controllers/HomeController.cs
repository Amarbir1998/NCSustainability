using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NCSustainability.Data;
using NCSustainability.Models;

namespace NCSustainability.Controllers
{
    public class HomeController : Controller
    {
        private readonly NCDbContext _context;

        public HomeController(NCDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var nCDbContext = _context.Events.Include(ec => ec.EventCategory);
            return View(await nCDbContext.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }
        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .Include(ec => ec.EventCategory)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NCSustainability.Data;
using NCSustainability.Models;

namespace NCSustainability.Controllers
{
    public class LikedFunfactsController : Controller
    {
        private readonly NCDbContext _context;

        public LikedFunfactsController(NCDbContext context)
        {
            _context = context;
        }

        // GET: LikedFunfacts
        public async Task<IActionResult> Index()
        {
            var nCDbContext = _context.LikedFunfacts.Include(l => l.FunFact);
            return View(await nCDbContext.ToListAsync());
        }

        // GET: LikedFunfacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var likedFunfact = await _context.LikedFunfacts
                .Include(l => l.FunFact)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (likedFunfact == null)
            {
                return NotFound();
            }

            return View(likedFunfact);
        }

        // GET: LikedFunfacts/Create
        public IActionResult Create()
        {
            ViewData["FunfactID"] = new SelectList(_context.FunFacts, "ID", "Email");
            return View();
        }

        // POST: LikedFunfacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LName,Email,FunfactID")] LikedFunfact likedFunfact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(likedFunfact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FunfactID"] = new SelectList(_context.FunFacts, "ID", "Email", likedFunfact.FunfactID);
            return View(likedFunfact);
        }

        // GET: LikedFunfacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var likedFunfact = await _context.LikedFunfacts.FindAsync(id);
            if (likedFunfact == null)
            {
                return NotFound();
            }
            ViewData["FunfactID"] = new SelectList(_context.FunFacts, "ID", "Email", likedFunfact.FunfactID);
            return View(likedFunfact);
        }

        // POST: LikedFunfacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LName,Email,FunfactID")] LikedFunfact likedFunfact)
        {
            if (id != likedFunfact.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(likedFunfact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LikedFunfactExists(likedFunfact.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FunfactID"] = new SelectList(_context.FunFacts, "ID", "Email", likedFunfact.FunfactID);
            return View(likedFunfact);
        }

        // GET: LikedFunfacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var likedFunfact = await _context.LikedFunfacts
                .Include(l => l.FunFact)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (likedFunfact == null)
            {
                return NotFound();
            }

            return View(likedFunfact);
        }

        // POST: LikedFunfacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var likedFunfact = await _context.LikedFunfacts.FindAsync(id);
            _context.LikedFunfacts.Remove(likedFunfact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LikedFunfactExists(int id)
        {
            return _context.LikedFunfacts.Any(e => e.ID == id);
        }
    }
}

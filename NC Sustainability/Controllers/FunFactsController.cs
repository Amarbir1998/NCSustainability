using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NCSustainability.Data;
using NCSustainability.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NCSustainability.Controllers
{
    public class FunFactsController : Controller
    {

        private readonly NCDbContext _context;

        public FunFactsController(NCDbContext context)
        {
            _context = context;
        }

        // GET: EventCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.FunFacts.ToListAsync());
        }

        // GET: FunFacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funFacts = await _context.FunFacts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (funFacts == null)
            {
                return NotFound();
            }

            return View(funFacts);
        }



        // GET: FunFacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Email,FunFactDescription")] FunFact funFacts, IFormFile thePicture)
        {
            if (ModelState.IsValid)
            {
                if (thePicture != null)
                {
                    string mimeType = thePicture.ContentType;
                    long fileLength = thePicture.Length;
                    if (!(mimeType == "" || fileLength == 0))//Looks like we have a file!!!
                    {
                        if (mimeType.Contains("image"))
                        {
                            using (var memoryStream = new MemoryStream())
                            {
                                await thePicture.CopyToAsync(memoryStream);
                                funFacts.imageContent = memoryStream.ToArray();
                            }
                            funFacts.imageMimeType = mimeType;
                            funFacts.imageFileName = thePicture.FileName;
                        }
                    }
                }
                _context.Add(funFacts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funFacts);
        }

        // GET: FunFact/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funFacts = await _context.FunFacts.FindAsync(id);
            if (funFacts == null)
            {
                return NotFound();
            }
            return View(funFacts);
        }

        // POST: FunFacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Email,FunFactDescription")] FunFact funFact)
        {
            if (id != funFact.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funFact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FunFactsExists(funFact.ID))
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
            return View(funFact);
        }

        // GET: FunFact/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funFact = await _context.FunFact
                .FirstOrDefaultAsync(m => m.ID == id);
            if (funFact == null)
            {
                return NotFound();
            }

            return View(funFact);
        }

        // POST: FunFact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funFact = await _context.FunFact.FindAsync(id);
            _context.FunFact.Remove(funFact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FunFactsExists(int id)
        {
            return _context.FunFact.Any(e => e.ID == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NCSustainability.Data;
using NCSustainability.Models;

namespace NCSustainability.Controllers
{
    public class PromotionsController : Controller
    {
        private readonly NCDbContext _context;

        public PromotionsController(NCDbContext context)
        {
            _context = context;
        }

        // GET: Promotions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Promotions.ToListAsync());
        }

        // GET: Promotions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promotion = await _context.Promotions
                .FirstOrDefaultAsync(m => m.ID == id);
            if (promotion == null)
            {
                return NotFound();
            }

            return View(promotion);
        }

        // GET: Promotions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Promotions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,SPdate,EPdate")] Promotion promotion, IFormFile thePicture)
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
                                promotion.imageContent = memoryStream.ToArray();
                            }
                            promotion.imageMimeType = mimeType;
                            promotion.imageFileName = thePicture.FileName;
                        }
                    }
                }
                _context.Add(promotion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promotion);
        }

        // GET: Promotions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promotion = await _context.Promotions.FindAsync(id);
            if (promotion == null)
            {
                return NotFound();
            }
            return View(promotion);
        }

        // POST: Promotions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,SPdate,EPdate")] Promotion promotion, string chkRemoveImage, IFormFile thePicture)
        {
            if (id != promotion.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //For the image
                    if (chkRemoveImage != null)
                    {
                        promotion.imageContent = null;
                        promotion.imageMimeType = null;
                        promotion.imageFileName = null;
                    }
                    else
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
                                        promotion.imageContent = memoryStream.ToArray();
                                    }
                                    promotion.imageMimeType = mimeType;
                                    promotion.imageFileName = thePicture.FileName;
                                }
                            }
                        }
                    }
                    _context.Update(promotion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromotionExists(promotion.ID))
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
            return View(promotion);
        }

        // GET: Promotions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promotion = await _context.Promotions
                .FirstOrDefaultAsync(m => m.ID == id);
            if (promotion == null)
            {
                return NotFound();
            }

            return View(promotion);
        }

        // POST: Promotions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promotion = await _context.Promotions.FindAsync(id);
            _context.Promotions.Remove(promotion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromotionExists(int id)
        {
            return _context.Promotions.Any(e => e.ID == id);
        }
    }
}

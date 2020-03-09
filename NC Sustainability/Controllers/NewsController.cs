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
    public class NewsController : Controller
    {
        private readonly NCDbContext _context;

        public NewsController(NCDbContext context)
        {
            _context = context;
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            return View(await _context.News.ToListAsync());
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @new = await _context.News
                .FirstOrDefaultAsync(m => m.ID == id);
            if (@new == null)
            {
                return NotFound();
            }

            return View(@new);
        }

        // GET: News/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Description,Pdate")] New @new, IFormFile thePicture)
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
                                @new.imageContent = memoryStream.ToArray();
                            }
                            @new.imageMimeType = mimeType;
                            @new.imageFileName = thePicture.FileName;
                        }
                    }
                }
                _context.Add(@new);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@new);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @new = await _context.News.FindAsync(id);
            if (@new == null)
            {
                return NotFound();
            }
            return View(@new);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Description,Pdate")] New @new, string chkRemoveImage, IFormFile thePicture)
        {
            if (id != @new.ID)
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
                        @new.imageContent = null;
                        @new.imageMimeType = null;
                        @new.imageFileName = null;
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
                                        @new.imageContent = memoryStream.ToArray();
                                    }
                                    @new.imageMimeType = mimeType;
                                    @new.imageFileName = thePicture.FileName;
                                }
                            }
                        }
                    }
                    _context.Update(@new);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewExists(@new.ID))
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
            return View(@new);
        }

        // GET: News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @new = await _context.News
                .FirstOrDefaultAsync(m => m.ID == id);
            if (@new == null)
            {
                return NotFound();
            }

            return View(@new);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @new = await _context.News.FindAsync(id);
            _context.News.Remove(@new);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewExists(int id)
        {
            return _context.News.Any(e => e.ID == id);
        }
    }
}

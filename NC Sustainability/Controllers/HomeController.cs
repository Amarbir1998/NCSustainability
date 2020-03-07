using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NCSustainability.Data;
using NCSustainability.Models;
using NCSustainability.ViewModels;

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
            var NCContext = _context.Promotions;
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

        /// <summary>
        ///           Subscriber Area Starts
        /// </summary>
        /// <returns> </returns>

        // GET: Subscribers/Create
        public IActionResult Subscribe()
        {
            var subscriber = new Subscriber();
            subscriber.EventSubscribers = new List<EventSubscriber>();
            PopulateAssignedEventCategoryData(subscriber);
            return View();
        }

        // POST: Subscribers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Subscribe([Bind("ID,Name,Email,Phone")] Subscriber subscriber, string[] selectedOptions)
        {
            try
            {
                //Add the selected categories
                if (selectedOptions != null)
                {
                    subscriber.EventSubscribers = new List<EventSubscriber>();
                    foreach (var category in selectedOptions)
                    {
                        var categoryToAdd = new EventSubscriber { SubscriberID = subscriber.ID, EventCategoryID = int.Parse(category) };
                        subscriber.EventSubscribers.Add(categoryToAdd);
                    }
                }
                if (ModelState.IsValid)
                {
                    _context.Add(subscriber);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unnknown error!");
            }
            PopulateAssignedEventCategoryData(subscriber);
            return View(subscriber);
        }


        // GET: FunFacts/Create
        public IActionResult Fun()
        {
            return View();
        }

        // POST: EventCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Fun([Bind("ID,Title,Email,FunFactDescription")] FunFact funFacts, IFormFile thePicture)
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


        private void PopulateAssignedEventCategoryData(Subscriber subscriber)
        {
            var allCategories = _context.FunFact;
            var pCategories = new HashSet<int>(subscriber.EventSubscribers.Select(b => b.EventCategoryID));
            var checkBoxes = new List<AssignedOptionVM>();
            foreach (var category in allCategories)
            {
                checkBoxes.Add(new AssignedOptionVM
                {
                    ID = category.ID,
                    DisplayText = category.EventCategoryName,
                    Assigned = pCategories.Contains(category.ID)
                });
            }
            ViewData["EventCategories"] = checkBoxes;
        }



        /// <summary>
        ///             Subscriber area ENDS
        /// </summary>
        /// <returns>   Subscribe the event Categories   </returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NCSustainability.Data;
using NCSustainability.Models;
using NCSustainability.ViewModels;

namespace NC_Sustainability.Controllers
{
    public class SubscribersController : Controller
    {
        private readonly NCDbContext _context;

        public SubscribersController(NCDbContext context)
        {
            _context = context;
        }

        // GET: Subscribers
        public async Task<IActionResult> Index()
        {
            ViewData["CategoryID"] = new SelectList(_context
                .EventCategories
                .OrderBy(c => c.EventCategoryName), "ID", "EventCategoryName");

            var subscribers = from d in _context.subscribers
                              .Include(p => p.EventSubscribers)
                              .ThenInclude(pc => pc.EventCategory)
                              select d;

            return View(subscribers);
        }

        // GET: Subscribers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriber = await _context.subscribers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (subscriber == null)
            {
                return NotFound();
            }

            return View(subscriber);
        }

        // GET: Subscribers/Create
        public IActionResult Create()
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
        public async Task<IActionResult> Create([Bind("ID,Name,Email")] Subscriber subscriber, string[] selectedOptions)
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

        // GET: Subscribers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriber = await _context.subscribers
                .Include(p => p.EventSubscribers)
                .ThenInclude(p => p.EventCategory)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.ID == id);

            if (subscriber == null)
            {
                return NotFound();
            }

            PopulateAssignedEventCategoryData(subscriber);
            return View(subscriber);
        }

        // POST: Subscribers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string[] selectedOptions)//', [Bind("ID,Name,Email")] Subscriber subscriber)
        {
            var subscriberToUpdate = await _context.subscribers
                .Include(p => p.EventSubscribers)
                .ThenInclude(p => p.EventCategory)
                .SingleOrDefaultAsync(p => p.ID == id);
            //Check that you got it or exit with a not found error
            if (subscriberToUpdate == null)
            {
                return NotFound();
            }


            //Update the Category subscribed
            UpdateEventSubscribers(selectedOptions, subscriberToUpdate);


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subscriberToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubscriberExists(subscriberToUpdate.ID))
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
            return View(subscriberToUpdate);
        }

        // GET: Subscribers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscriber = await _context.subscribers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (subscriber == null)
            {
                return NotFound();
            }

            return View(subscriber);
        }

        // POST: Subscribers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subscriber = await _context.subscribers.FindAsync(id);
            _context.subscribers.Remove(subscriber);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubscriberExists(int id)
        {
            return _context.subscribers.Any(e => e.ID == id);
        }

        private void PopulateAssignedEventCategoryData(Subscriber subscriber)
        {
            var allCategories = _context.EventCategories;
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

        private void UpdateEventSubscribers(string[] selectedOptions, Subscriber subscriberToUpdate)
        {
            if (selectedOptions == null)
            {
                subscriberToUpdate.EventSubscribers = new List<EventSubscriber>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedOptions);
            var EventSubscribersHS = new HashSet<int>
                (subscriberToUpdate.EventSubscribers.Select(c => c.EventCategoryID));//IDs of the currently selected conditions
            foreach (var category in _context.EventCategories)
            {
                if (selectedCategoriesHS.Contains(category.ID.ToString()))
                {
                    if (!EventSubscribersHS.Contains(category.ID))
                    {
                        subscriberToUpdate.EventSubscribers.Add(new EventSubscriber { SubscriberID = subscriberToUpdate.ID, EventCategoryID = category.ID });
                    }
                }
                else
                {
                    if (EventSubscribersHS.Contains(category.ID))
                    {
                        EventSubscriber categoryToRemove = subscriberToUpdate.EventSubscribers.SingleOrDefault(c => c.EventCategoryID == category.ID);
                        _context.Remove(categoryToRemove);
                    }
                }
            }
        }
    }
}

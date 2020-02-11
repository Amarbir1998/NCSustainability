﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MailKit;
using MailKit.Net.Smtp;
using NC_Sustainability.Data;
using NC_Sustainability.Models;
using System.Web.Mvc;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using System.Web.Helpers;

namespace NC_Sustainability.Controllers
{
    public class EventsController : Controller
    {
        private readonly NCDbContext _context;

        public EventsController(NCDbContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {

            var nCDbContext = _context.Events.Include(ec => ec.EventCategory);
            return View(await nCDbContext.ToListAsync());
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

        // GET: Events/Create
        public IActionResult Create()
        {

            ViewData["EventCategoryID"] = new SelectList(_context.Set<EventCategory>(), "ID", "ID");


            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Edate,EventDescription,EventCategoryID")] Event e)
        {
            if (ModelState.IsValid)
            {
                _context.Add(e);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////_______Added Code From____________/////////////////////////////////
            ///////           https://dotnetcoretutorials.com/2017/11/02/         /////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////
            
            ViewData["EventCategoryID"] = new SelectList(_context.Set<EventCategory>(), "ID", "ID", e.EventCategory.EventCategoryName);
            return View(e);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            ViewData["EventCategoryID"] = new SelectList(_context.Set<EventCategory>(), "ID", "ID", @event.EventCategoryID);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Edate,EventDescription,EventCategoryID")] Event @event)
        {
            if (id != @event.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.ID))
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
            ViewData["EventCategoryID"] = new SelectList(_context.Set<EventCategory>(), "ID", "ID", @event.EventCategoryID);
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.ID == id);
        }

        //public void Send(Event @event)
        //{
        //    var message = new MimeMessage();
        //    message.To.AddRange(@event.ToAddresses.Select(x => new MailboxAddress(x.Name, x.Email)));
        //    message.From.AddRange(@event.FromAddresses.Select(x => new MailboxAddress(x.Name, x.Email)));

        //    message.Subject = @event.Title;
        //    //We will say we are sending HTML. But there are options for plaintext etc. 
        //    message.Body = new TextPart("plain")
        //    {
        //        Text = @event.EventDescription
        //    };

        //    //Be careful that the SmtpClient class is the one from Mailkit not the framework!
        //    using (var emailClient = new MailKit.Net.Smtp.SmtpClient())
        //    {
        //        emailClient.ServerCertificateValidationCallback = (s, c, h, e) => true;

        //        emailClient.Connect("smtp-mail.gmail.com",587, false);


        //        emailClient.Authenticate("asbhinder3@gmail.com","Amar1234@");

        //        emailClient.Send(message);

        //        emailClient.Disconnect(true);
        //    }

        //}


        public ActionResult SendMailToUser()
        {
            //bool result = false;
            //result = SendEmail();

            //return Json(result, JsonRequestBehaviour.)

            string recipient = "amarbir_3@live.com";
            string subject = "Email Testing";
            string body = "Testing Testing to send email";

            WebMail.SmtpServer = "smtp.gmail.com";
            WebMail.SmtpPort = 587;
            WebMail.SmtpUseDefaultCredentials = true;
            WebMail.EnableSsl = true;
            WebMail.UserName = "sustainability@outlook.com";
            WebMail.Password = "Sustainability1234@";

            WebMail.Send(to: recipient, subject: subject, body: body, isBodyHtml: true);
            return View();
        }
    }
}

//public void Sesnd()
//{

//    var message = new MimeMessage();
//    message.From.Add(new MailboxAddress("Amarbir", "ncsustainability@outlook.com"));
//    message.To.Add(new MailboxAddress("Karanvir", "singhkaranvir72@gmail.com"));
//    ///////////////////////////////////////////////////////////////////////////////////////////////
//    message.Subject = "Email send test";
//    //We will say we are sending HTML. But there are options for plaintext etc. 
//    message.Body = new TextPart("plain")
//    {
//        Text = @"Testing... Testing email sending..."
//    };

//    //Be careful that the SmtpClient class is the one from Mailkit not the framework!
//    using (var emailClient = new SmtpClient())
//    {
//        emailClient.ServerCertificateValidationCallback = (s, c, h, e) => true;

//        emailClient.Connect("smtp-mail.outlook.com", 587, false);

//        //Configure an SmtpClient to send the mail.

//        //emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
//        //emailClient.EnableSsl = false;
//        //emailClient.Host = "relay-hosting.secureserver.net";
//        //emailClient.Port = 25;

//        emailClient.Authenticate("ncsustainability@outlook.com", "Sustainability1234@");

//        emailClient.Send(message);

//        emailClient.Disconnect(true);
//    }
//}
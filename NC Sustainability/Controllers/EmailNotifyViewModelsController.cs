using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NC_Sustainability.Data;
using NC_Sustainability.Models;
using NC_Sustainability.Resources.Constants;

namespace NC_Sustainability.Controllers
{
    public class EmailNotifyViewModelsController : Controller
    {
        private readonly NCDbContext _context;

        public EmailNotifyViewModelsController(NCDbContext context)
        {
            _context = context;
        }

        // GET: EmailNotifyViewModels
        public async Task<IActionResult> Index(EmailNotifyViewModel model)
        {
            try
            {
                // Verification  
                if (ModelState.IsValid)
                {
                    // Initialization.  
                    string emailMsg = "Dear " + model.ToEmail + ", <br /><br /> Thist is test <b style='color: red'> Notification </b> <br /><br /> Thanks & Regards, <br />Team 09";
                    string emailSubject = EmailInfo.EMAIL_SUBJECT_DEFAUALT + " Test";

                    // Sending Email.  
                    await this.SendEmailAsync(model.ToEmail, emailMsg, emailSubject);


                    // Info.  
                    return this.Json(new { EnableSuccess = true, SuccessTitle = "Success", SuccessMsg = "Notification has been sent successfully! to '" + model.ToEmail + "' Check your email." });
                }
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);

                // Info  
                return this.Json(new { EnableError = true, ErrorTitle = "Error", ErrorMsg = ex.Message });
            }

            // Info  
            return this.Json(new { EnableError = true, ErrorTitle = "Error", ErrorMsg = "Something goes wrong, please try again later" });
        }

        // GET: EmailNotifyViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emailNotifyViewModel = await _context.EmailNotifyViewModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (emailNotifyViewModel == null)
            {
                return NotFound();
            }

            return View(emailNotifyViewModel);
        }

        // GET: EmailNotifyViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmailNotifyViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ToEmail")] EmailNotifyViewModel emailNotifyViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emailNotifyViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emailNotifyViewModel);
        }

        // GET: EmailNotifyViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emailNotifyViewModel = await _context.EmailNotifyViewModel.FindAsync(id);
            if (emailNotifyViewModel == null)
            {
                return NotFound();
            }
            return View(emailNotifyViewModel);
        }

        // POST: EmailNotifyViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ToEmail")] EmailNotifyViewModel emailNotifyViewModel)
        {
            if (id != emailNotifyViewModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emailNotifyViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmailNotifyViewModelExists(emailNotifyViewModel.ID))
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
            return View(emailNotifyViewModel);
        }

        // GET: EmailNotifyViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emailNotifyViewModel = await _context.EmailNotifyViewModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (emailNotifyViewModel == null)
            {
                return NotFound();
            }

            return View(emailNotifyViewModel);
        }

        // POST: EmailNotifyViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emailNotifyViewModel = await _context.EmailNotifyViewModel.FindAsync(id);
            _context.EmailNotifyViewModel.Remove(emailNotifyViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmailNotifyViewModelExists(int id)
        {
            return _context.EmailNotifyViewModel.Any(e => e.ID == id);
        }
        /// <summary>  
        ///  Send Email method.  
        /// </summary>  
        /// <param name="email">Email parameter</param>  
        /// <param name="msg">Message parameter</param>  
        /// <param name="subject">Subject parameter</param>  
        /// <returns>Return await task</returns>  
        public async Task<bool> SendEmailAsync(string email, string msg, string subject = "")
        {
            // Initialization.  
            bool isSend = false;

            try
            {
                // Initialization.  
                var body = msg;
                var message = new MailMessage();

                // Settings.  
                message.To.Add(new MailAddress(email));
                message.From = new MailAddress(EmailInfo.FROM_EMAIL_ACCOUNT);
                message.Subject = !string.IsNullOrEmpty(subject) ? subject : EmailInfo.EMAIL_SUBJECT_DEFAUALT;
                message.Body = body;
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    // Settings.  
                    var credential = new NetworkCredential
                    {
                        UserName = EmailInfo.FROM_EMAIL_ACCOUNT,
                        Password = EmailInfo.FROM_EMAIL_PASSWORD
                    };

                    // Settings.  
                    smtp.Credentials = credential;
                    smtp.Host = EmailInfo.SMTP_HOST_GMAIL;
                    smtp.Port = Convert.ToInt32(EmailInfo.SMTP_PORT_GMAIL);
                    smtp.EnableSsl = true;

                    // Sending  
                    await smtp.SendMailAsync(message);

                    // Settings.  
                    isSend = true;
                }
            }
            catch (Exception ex)
            {
                // Info  
                throw ex;
            }

            // info.  
            return isSend;
        }

    }
}

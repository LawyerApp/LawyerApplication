using LawyerApp.Areas.LawyerAdminPanel.Models;
using LawyerApp.Areas.LawyerAdminPanel.Models.ViewModels;
using LawyerApp.Infrastructures;
using LawyerApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LawyerApp.Areas.LawyerAdminPanel.Controllers
{
    [Area(nameof(LawyerAdminPanel))]
    [Authorize]
    public class MessageController:Controller
    {
        private readonly LawyerDbContext lawyerDbContext;

        public MessageController(LawyerDbContext lawyerDbContext)
        {
            this.lawyerDbContext = lawyerDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<MessageDto> messages = await lawyerDbContext.Messages.Select(m=>new MessageDto
                                                                                            {
                                                                                                 Id=m.Id,
                                                                                                 Email=m.Email,
                                                                                                 Name=m.Name,
                                                                                                 Status=m.Status
                                                                                            }).ToListAsync();
            return View(messages);
        }

        [HttpGet]
        public async Task<IActionResult> Reply([Required][FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Message message = await lawyerDbContext.Messages.FindAsync(id);

                    if (message == null)
                        throw new NullReferenceException();

                    return View(new Message
                    {
                        Id =message.Id
                    });
                }
                catch { }
            }
            return RedirectToAction(nameof(Index));
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reply([Required][FromForm] int id, MessageReplyModel message , [FromServices]EmailService service)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Message result = await lawyerDbContext.Messages.FindAsync(id);

                    if (result != null)
                    {
                        await service.SendMailAsync(result.Email, message.Subject, message.MessageContent);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                        throw new Exception();
                    
                }
                catch 
                {
                    ModelState.AddModelError("", "Some error occured. Please contact the administrator for the solution!");
                }
            }
            return View(message);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([Required][FromForm] int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Message message = await lawyerDbContext.Messages.FindAsync(id);

                    if (message == null)
                        throw new NullReferenceException();

                    lawyerDbContext.Messages.Remove(message);
                    await lawyerDbContext.SaveChangesAsync();

                    return Json(new
                    {
                        status = HttpStatusCode.OK
                    });
                }
                catch { }
            }
            return Json(new
            {
                status = HttpStatusCode.NotFound
            });
        }

        [HttpGet]
        public async Task<IActionResult> Details([Required][FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Message message = await lawyerDbContext.Messages.FindAsync(id);

                    if (message == null)
                        throw new NullReferenceException();

                    message.Status = true;
                    await lawyerDbContext.SaveChangesAsync();

                    return View(message);
                }
                catch { }

            }
            return RedirectToAction(nameof(Index));
        }
    }
}

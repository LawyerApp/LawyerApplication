using LawyerApp.Areas.LawyerAdminPanel.Models;
using LawyerApp.Infrastructures;
using LawyerApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Areas.LawyerAdminPanel.Controllers
{
    [Area(nameof(LawyerAdminPanel))]
    [Authorize]
    public class ContactController:Controller
    {
        private readonly LawyerDbContext lawyerDbContext;

        public ContactController(LawyerDbContext lawyerDbContext)
        {
            this.lawyerDbContext = lawyerDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<ContactDto> ContatViews = (await lawyerDbContext.GetContactViewAsync())
                                                                              .Where(m => m.LanguageId == DbContextService.GetLanguageIdByShortName(lawyerDbContext));
            return View(ContatViews);
        }

        [HttpGet]
        public async Task<IActionResult> Edit([Required][FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    StaticData staticData = await lawyerDbContext.StaticDatas.FindAsync(id);

                    ContactViewModel contactViewModel = new ContactViewModel
                    {
                        Id = id,
                        ContactEmail = staticData.ContactEmail,
                        ContactNumber = staticData.ContactNumber,
                        ContactAdresses = (await lawyerDbContext.GetContactViewAsync())
                        .Select(m => new ContactMap
                        {
                            ContactAdress = m.ContactAdress,
                            LanguageId = m.LanguageId
                        })
                        .OrderBy(m => m.LanguageId).ToList(),

                        Languages = await lawyerDbContext.Languages
                                                            .AsNoTracking()
                                                               .ToListAsync()
                    };

                    return View(contactViewModel);
                }
                catch { }
               
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Required][FromForm] int id, ContactEditModel contactEditModel)
        {
            if (ModelState.IsValid)
            {
                IDbContextTransaction transaction = null;
                try
                {
                    transaction = await lawyerDbContext.Database.BeginTransactionAsync();

                    StaticData staticData = await lawyerDbContext.StaticDatas.FindAsync(id);

                    if (staticData == null)
                        throw new NullReferenceException();

                    staticData.ContactEmail = contactEditModel.ContactEmail;
                    staticData.ContactNumber = contactEditModel.ContactNumber;

                    IEnumerable<Text> adressTextAllLanguage = await lawyerDbContext.Texts
                                                                                      .Where(m => m.Key == staticData.ContactAdressKey)
                                                                                           .ToListAsync();

                    //Update texts all language for properties
                    foreach (var item in contactEditModel.ContactAdresses)
                    {
                        Text adress = adressTextAllLanguage.SingleOrDefault(m => m.LanguageId == item.LanguageId);
                        adress.TextContent = item.ContactAdress;
                    }

                    await lawyerDbContext.SaveChangesAsync();

                    transaction.Commit();

                    return RedirectToAction(nameof(Index));
                }

                catch (NullReferenceException exp)
                {
                    ModelState.AddModelError("", exp.Message);
                }

                catch
                {
                    transaction.Rollback();

                    ModelState.AddModelError("", "Some error occured. Please try again.");
                }
                finally
                {
                    if (transaction != null)
                        transaction.Dispose();
                }
            }

            ContactViewModel contactViewModel = new ContactViewModel
            {
                Id = id,
                ContactEmail = contactEditModel.ContactEmail,
                ContactNumber = contactEditModel.ContactNumber,
                ContactAdresses = contactEditModel.ContactAdresses,
                Languages = await lawyerDbContext.Languages
                                                     .AsNoTracking()
                                                          .ToListAsync()
            };
            return View(contactViewModel);
        }

    }
}

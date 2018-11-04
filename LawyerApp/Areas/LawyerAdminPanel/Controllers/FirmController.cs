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
    public class FirmController:Controller
    {
        private readonly LawyerDbContext lawyerDbContext;

        public FirmController(LawyerDbContext lawyerDbContext)
        {
            this.lawyerDbContext = lawyerDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<FirmDto> firmViews = (await lawyerDbContext.GetFirmViewAsync())
                                                                       .Where(m => m.LanguageId == DbContextService.GetLanguageIdByShortName(lawyerDbContext)).ToList();
            return View(firmViews);
        }

        [HttpGet]
        public async Task<IActionResult> Edit([Required][FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    StaticData staticData = await lawyerDbContext.StaticDatas.FindAsync(id);

                    FirmViewModel firmViewModel = new FirmViewModel
                    {
                        Id = id,
                        Firms = (await lawyerDbContext.GetFirmViewAsync())
                        .Select(m => new FirmMap
                        {
                            Title = m.Title,
                            Description = m.Description,
                            LanguageId=m.LanguageId
                        })
                        .OrderBy(m => m.LanguageId).ToList(),

                        Languages = await lawyerDbContext.Languages
                                                            .AsNoTracking()
                                                               .ToListAsync()
                    };

                    return View(firmViewModel);
                }
                catch { }

            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Required][FromForm] int id, FirmEditModel firmEditModel)
        {
            if (ModelState.IsValid)
            {
                IDbContextTransaction transaction = null;
                try
                {
                    transaction = await lawyerDbContext.Database.BeginTransactionAsync();

                    StaticData staticData = await lawyerDbContext.StaticDatas.FindAsync(id);

                    if (staticData == null)
                        throw new NullReferenceException("This firm doesn't exist. ");

                    if (firmEditModel.Img != null)
                    {
                        string fileName = staticData.OurFirmImg;
                        staticData.OurFirmImg = await FileService.UploadImageAsync(firmEditModel.Img, "Uploads");
                        FileService.DeleteFile(fileName, "Uploads");
                    }

                    IEnumerable<Text> titleTextAllLanguage = await lawyerDbContext.Texts
                                                                                      .Where(m => m.Key == staticData.OurFirmTitleKey)
                                                                                           .ToListAsync();
                    IEnumerable<Text> descriptionTextAllLanguage = await lawyerDbContext.Texts
                                                                                           .Where(m => m.Key == staticData.OurFirmDescriptionKey)
                                                                                             .ToListAsync();

                    //Update texts all language for properties
                    foreach (var item in firmEditModel.Firms)
                    {
                        Text title = titleTextAllLanguage.SingleOrDefault(m => m.LanguageId == item.LanguageId);
                        title.TextContent = item.Title;
                    }

                    foreach (var item in firmEditModel.Firms)
                    {
                        Text description = descriptionTextAllLanguage.SingleOrDefault(m => m.LanguageId == item.LanguageId);
                        description.TextContent = item.Description;
                    }

                    

                    await lawyerDbContext.SaveChangesAsync();

                    transaction.Commit();

                    return RedirectToAction(nameof(Index));
                }

                catch (NullReferenceException exp)
                {
                    ModelState.AddModelError("", exp.Message);
                }

                catch (ArgumentNullException exp)
                {
                    ModelState.AddModelError("img", exp.Message);
                }

                catch (InvalidContentTypeException exp)
                {
                    ModelState.AddModelError("img", exp.Message);
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

            FirmViewModel firmViewModel = new FirmViewModel
            {
                Id = id,
                Img=null,
                Firms=firmEditModel.Firms,
                Languages = await lawyerDbContext.Languages
                                                     .AsNoTracking()
                                                          .ToListAsync()
            };
            return View(firmViewModel);
        }
    }
}

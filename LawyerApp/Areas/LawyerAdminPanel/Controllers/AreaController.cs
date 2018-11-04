using LawyerApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LawyerApp.Infrastructures;
using LawyerApp.Areas.LawyerAdminPanel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace LawyerApp.Areas.LawyerAdminPanel.Controllers
{
    [Area(nameof(LawyerAdminPanel))]
    [Authorize]
    public class AreaController:Controller
    {
        private readonly LawyerDbContext lawyerDbContext;

        public AreaController(LawyerDbContext lawyerDbContext)
        {
            this.lawyerDbContext = lawyerDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AreaDto> areaViews = (await lawyerDbContext.GetAreaViewAsync())
                                                                           .Where(m=>m.LanguageId==DbContextService.GetLanguageIdByShortName(lawyerDbContext));
            return View(areaViews);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                AreaViewModel areaViewModel = new AreaViewModel
                {
                    Languages = await lawyerDbContext.Languages
                                                    .AsNoTracking()
                                                        .ToListAsync()
                };

                return View(areaViewModel);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AreaCreateModel areaCreateModel)
        {
            if (ModelState.IsValid)
            {
                IDbContextTransaction transaction = null;

                try
                {
                    transaction = await lawyerDbContext.Database.BeginTransactionAsync();

                    Area area = new Area
                    {
                        NameKey = DbContextService.GenerateKey("area_name"),
                        DescriptionKey = DbContextService.GenerateKey("desc"),
                        MeetingMinute = areaCreateModel.MeetingMinute,
                    };

                    IEnumerable<Text> areaNameForAllLangueges = areaCreateModel.Areas.Select(m => new Text
                    {
                        Key = area.NameKey,
                        TextContent = m.Name,
                        LanguageId = m.LanguageId
                    });

                    await lawyerDbContext.Texts.AddRangeAsync(areaNameForAllLangueges);

                    IEnumerable<Text> areaDescriptionForAllLangueges = areaCreateModel.Areas.Select(m => new Text
                    {
                        Key = area.DescriptionKey,
                        TextContent = m.Description,
                        LanguageId = m.LanguageId
                    });

                    await lawyerDbContext.Areas.AddAsync(area);

                    await lawyerDbContext.Texts.AddRangeAsync(areaDescriptionForAllLangueges);

                    await lawyerDbContext.SaveChangesAsync();

                    transaction.Commit();

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    transaction.Rollback();

                    ModelState.AddModelError("", "Some error occured ! Please try again .");
                }

                finally
                {
                    if (transaction != null)
                        transaction.Dispose();
                }
            }

            AreaViewModel areaViewModel = new AreaViewModel
            {
                Languages = await lawyerDbContext.Languages
                                                     .AsNoTracking()
                                                          .ToListAsync(),
                Areas = areaCreateModel.Areas,
                MeetingMinute = areaCreateModel.MeetingMinute
            };

            return View(areaViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit([Required][FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AreaViewModel areaViewModel = new AreaViewModel
                    {
                        Id = id,
                        Areas = (await lawyerDbContext.GetAreaViewAsync())
                                                     .Where(m => m.Id == id)
                                                         .Select(m => new AreaMap
                                                         {
                                                             Name = m.Name,
                                                             Description = m.Description,
                                                             LanguageId = m.LanguageId
                                                         })
                                                                .OrderBy(m => m.LanguageId).ToList(),
                        Languages = await lawyerDbContext.Languages
                                                       .AsNoTracking()
                                                           .ToListAsync(),
                        MeetingMinute = (await lawyerDbContext.Areas.SingleOrDefaultAsync(m => m.Id == id)).MeetingMinute
                    };

                    return View(areaViewModel);
                }
                catch { }
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Required][FromForm] int id , AreaEditModel areaEditModel)
        {
            if (ModelState.IsValid)
            {
                IDbContextTransaction transaction = null;
                try
                {
                    transaction = await lawyerDbContext.Database.BeginTransactionAsync();

                    Area area = await lawyerDbContext.Areas.FindAsync(id);

                    if (area == null)
                        throw new NullReferenceException("This area doesn't exist. ");

                    area.MeetingMinute = areaEditModel.MeetingMinute;

                    IEnumerable<Text> nameTextAllLanguage = await lawyerDbContext.Texts
                                                                                   .Where(m => m.Key == area.NameKey)
                                                                                      .ToListAsync();

                    IEnumerable<Text> descriptionTextAllLanguage = await lawyerDbContext.Texts
                                                                                       .Where(m => m.Key == area.DescriptionKey)
                                                                                           .ToListAsync();

                    //Update texts all language for properties
                    foreach (var item in areaEditModel.Areas)
                    {
                        Text name = nameTextAllLanguage.SingleOrDefault(m => m.LanguageId == item.LanguageId);
                        name.TextContent = item.Name;
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

            AreaViewModel areaViewModel = new AreaViewModel
            {
                Id = id,
                Areas = areaEditModel.Areas,
                Languages = await lawyerDbContext.Languages
                                                      .AsNoTracking()
                                                            .ToListAsync(),
                MeetingMinute=areaEditModel.MeetingMinute
            };

            return View(areaViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([Required][FromForm] int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Area area = await lawyerDbContext.Areas.FindAsync(id);

                    if (area == null)
                        throw new NullReferenceException();

                    lawyerDbContext.Areas.Remove(area);
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
                    AreaDetailModel areaDetailModel = new AreaDetailModel
                    {
                        Areas = (await lawyerDbContext.GetAreaViewAsync())
                                                          .Where(m => m.Id == id)
                                                              ?.OrderBy(m => m.LanguageId),
                        Languages = await lawyerDbContext.Languages
                                                    .AsNoTracking()
                                                         .ToListAsync(),
                        MeetingMinute = (await lawyerDbContext.Areas.FindAsync(id)).MeetingMinute
                    };

                    return View(areaDetailModel);
                }
                catch { }
               
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

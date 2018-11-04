using LawyerApp.Areas.LawyerAdminPanel.Models;
using LawyerApp.Infrastructures;
using LawyerApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LawyerApp.Areas.LawyerAdminPanel.Controllers
{
    [Area(nameof(LawyerAdminPanel))]
    [Authorize]
    public class AboutController:Controller
    {
        private readonly LawyerDbContext lawyerDbContext;

        public AboutController(LawyerDbContext lawyerDbContext)
        {
            this.lawyerDbContext = lawyerDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<TeamServicesDto> teamServicesView = (await lawyerDbContext.GetTeamServicesViewAsync())
                                                                                        .Where(m=>m.LanguageId==DbContextService.GetLanguageIdByShortName(lawyerDbContext));
            return View(teamServicesView);
        }

        [HttpGet]
        public async Task<IActionResult> Edit([Required][FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    StaticData staticData = await lawyerDbContext.StaticDatas.FindAsync(id);

                    AboutViewModel aboutViewModel = new AboutViewModel
                    {
                        Id = id,
                        TeamServices = (await lawyerDbContext.GetTeamServicesViewAsync())
                        .Select(m => new AboutMap
                        {
                            OurTeamDescription = m.TeamDescription,
                            OurServicesDescription = m.ServicesDescription,
                            LanguageId = m.LanguageId
                        })
                        .OrderBy(m => m.LanguageId).ToList(),

                        Languages = await lawyerDbContext.Languages
                                                            .AsNoTracking()
                                                               .ToListAsync()
                    };

                    return View(aboutViewModel);
                }
                catch { }

            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Required][FromForm] int id, AboutEditModel aboutEditModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    StaticData staticData = await lawyerDbContext.StaticDatas.FindAsync(id);

                    if (staticData == null)
                        throw new NullReferenceException("This firm doesn't exist. ");

                    IEnumerable<Text> teamDescTextAllLanguage = await lawyerDbContext.Texts
                                                                                      .Where(m => m.Key == staticData.OurTeamDescriptionKey)
                                                                                           .ToListAsync();
                    IEnumerable<Text> serviceDescTextAllLanguage = await lawyerDbContext.Texts
                                                                                           .Where(m => m.Key == staticData.ServicesDescriptionKey)
                                                                                             .ToListAsync();

                    //Update texts all language for properties
                    foreach (var item in aboutEditModel.TeamServices)
                    {
                        Text team = teamDescTextAllLanguage.SingleOrDefault(m => m.LanguageId == item.LanguageId);
                        team.TextContent = item.OurTeamDescription;
                    }

                    foreach (var item in aboutEditModel.TeamServices)
                    {
                        Text service = serviceDescTextAllLanguage.SingleOrDefault(m => m.LanguageId == item.LanguageId);
                        service.TextContent = item.OurServicesDescription;
                    }

                    await lawyerDbContext.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }

                catch (NullReferenceException exp)
                {
                    ModelState.AddModelError("", exp.Message);
                }

                catch
                {
                    ModelState.AddModelError("", "Some error occured. Please try again.");
                }
            }

            AboutViewModel aboutViewModel = new AboutViewModel
            {
                Id = id,
                TeamServices=aboutEditModel.TeamServices,
                Languages = await lawyerDbContext.Languages
                                                     .AsNoTracking()
                                                          .ToListAsync()
            };
            return View(aboutViewModel);
        }
    }
}

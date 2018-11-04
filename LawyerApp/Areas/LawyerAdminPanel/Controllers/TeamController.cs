using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LawyerApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using LawyerApp.Areas.LawyerAdminPanel.Models;
using System.ComponentModel.DataAnnotations;
using LawyerApp.Infrastructures;
using System.Net;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LawyerApp.Areas.LawyerAdminPanel.Controllers
{
    [Area(nameof(LawyerAdminPanel))]
    [Authorize]
    public class TeamController : Controller
    {
        private readonly LawyerDbContext lawyerDbContext;

        public TeamController(LawyerDbContext lawyerDbContext)
        {
            this.lawyerDbContext = lawyerDbContext;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            int? languageId = DbContextService.GetLanguageIdByShortName(lawyerDbContext);
            IEnumerable<TeamMemberDto> teamMemberViews=  await lawyerDbContext.GetTeamMembersViewAsync();
            return View(teamMemberViews.Where(m=>m.LanguageId==languageId));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TeamMemberViewModel teamMemberViewModel = new TeamMemberViewModel
            {
               Languages = await lawyerDbContext.Languages
                                                      .AsNoTracking()
                                                             .ToListAsync(),
               Areas= (await lawyerDbContext.GetAreaViewAsync())
                                                  .Where(m=>m.LanguageId==DbContextService.GetLanguageIdByShortName(lawyerDbContext)).ToList()
            };
            return View(teamMemberViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(List<TeamMemberCreateModel> TeamMembers, [FromForm] byte Begin, [FromForm] byte End, IFormFile Img, List<int> AreaId)
        {
            if (ModelState.IsValid)
            {
                //Begin Transaction
                IDbContextTransaction transaction = null;
                try
                {
                    transaction = await lawyerDbContext.Database.BeginTransactionAsync();
                    // Generated key for each text
                    TeamMember teamMember = new TeamMember();
                    teamMember.NameKey =DbContextService.GenerateKey("name");
                    teamMember.SurnameKey = DbContextService.GenerateKey("surname");
                    teamMember.DescriptionKey = DbContextService.GenerateKey("desc");


                    teamMember.Img = await FileService.UploadImageAsync(Img, "Uploads");
                    teamMember.Begin = Begin;
                    teamMember.End = End;

                    //Add name with different language
                    IEnumerable<Text> nameDiffLangForText = TeamMembers.Select(m => new Text
                    {
                        Key = teamMember.NameKey,
                        TextContent = m.Name,
                        LanguageId = m.LanguageId

                    });

                    await lawyerDbContext.Texts.AddRangeAsync(nameDiffLangForText);

                    //Add surname with different language
                    IEnumerable<Text> surnameDiffLangForText = TeamMembers.Select(m => new Text
                    {
                        Key = teamMember.SurnameKey,
                        TextContent = m.Surname,
                        LanguageId = m.LanguageId

                    });

                    await lawyerDbContext.Texts.AddRangeAsync(surnameDiffLangForText);

                    //Add description with different language
                    IEnumerable<Text> descriptionDiffLangForText = TeamMembers.Select(m => new Text
                    {
                        Key = teamMember.DescriptionKey,
                        TextContent = m.Description,
                        LanguageId = m.LanguageId

                    });
                    await lawyerDbContext.Texts.AddRangeAsync(descriptionDiffLangForText);

                    await lawyerDbContext.AddAsync(teamMember);
                   
                    await lawyerDbContext.SaveChangesAsync();

                    IEnumerable<TeamToArea> teamToAreas = AreaId.Select(m => new TeamToArea
                    {
                         AreaId=m,
                         TeamMemberId=teamMember.Id
                    });

                    await lawyerDbContext.AddRangeAsync(teamToAreas);

                    await lawyerDbContext.SaveChangesAsync();
                    transaction.Commit();

                    return RedirectToAction(nameof(Index));
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

                    ModelState.AddModelError("", "Some error occured ! Please try again.");
                }

                finally
                {
                    if (transaction != null)
                        transaction.Dispose();
                }
            }

            TeamMemberViewModel teamMemberViewModel = new TeamMemberViewModel
            {
                Languages = await lawyerDbContext.Languages
                                                      .AsNoTracking()
                                                           .ToListAsync(),
                Areas = (await lawyerDbContext.GetAreaViewAsync())
                                                  .Where(m => m.LanguageId == DbContextService.GetLanguageIdByShortName(lawyerDbContext)).ToList()
            };
            return View(teamMemberViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit([Required][FromRoute]int id)
        {
            TeamMemberEditModel teamMemberEditModel = new TeamMemberEditModel();

            if (ModelState.IsValid)
            {
                try
                {
                    //Get member data all languages
                    IEnumerable<TeamMemberDto> teamMemberView = (await lawyerDbContext.GetTeamMembersViewAsync())
                                                                                             .Where(m => m.Id == id)
                                                                                                 .OrderBy(m=>m.LanguageId);
                    if (teamMemberView == null)
                        throw new InvalidOperationException();

                    //Mapping to view model
                    teamMemberEditModel.TeamMembers = teamMemberView.Select(m => new TeamMemberCreateModel
                    {
                        Name = m.Name,
                        Surname = m.Surname,
                        Description = m.Description,
                        LanguageId = m.LanguageId

                    }).ToList();
                    var teammember = teamMemberView.FirstOrDefault();
                    teamMemberEditModel.Id = id;
                    teamMemberEditModel.Begin = teammember.Begin;
                    teamMemberEditModel.End = teammember.End;
                    teamMemberEditModel.Languages = await lawyerDbContext.Languages
                                                                            .AsNoTracking()
                                                                                 .ToListAsync();

                    teamMemberEditModel.Areas = (await lawyerDbContext.GetAreaViewAsync())
                                                             .Where(m => m.LanguageId == DbContextService.GetLanguageIdByShortName(lawyerDbContext))?.ToList();

                    teamMemberEditModel.AreaId = lawyerDbContext.TeamToAreas.Where(m => m.TeamMemberId == id).Select(m=>m.AreaId).ToList();

                    return View(teamMemberEditModel);
                }
                catch (InvalidOperationException)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Required][FromForm]int id, List<TeamMemberCreateModel> TeamMembers, IFormFile Img, byte Begin, byte End, List<int> AreaId)
        {
            if (ModelState.IsValid)
            {
                IDbContextTransaction transaction = null;
                try
                {
                    transaction = await lawyerDbContext.Database.BeginTransactionAsync();

                    TeamMember teamMember = await lawyerDbContext.TeamMembers.FindAsync(id);
                    var teamToAreas = lawyerDbContext.TeamToAreas.Where(m => m.TeamMemberId == id).ToList();

                    if (teamMember == null)
                        throw new NullReferenceException("This member doesn't exist !!!");

                    teamMember.Begin = Begin;
                    teamMember.End = End;

                    if(Img != null)
                    {
                        string fileName = teamMember.Img;
                        teamMember.Img = await FileService.UploadImageAsync(Img, "Uploads");
                        FileService.DeleteFile(fileName, "Uploads");
                    }

                    lawyerDbContext.TeamToAreas.RemoveRange(teamToAreas);

                    IEnumerable<TeamToArea> teamToAreaInsert = AreaId.Select(m => new TeamToArea
                    {
                         AreaId=m,
                         TeamMemberId=id
                    });

                    await lawyerDbContext.TeamToAreas.AddRangeAsync(teamToAreaInsert);

                    IEnumerable<Text> nameTextAllLanguage= await lawyerDbContext.Texts
                                                                                   .Where(m => m.Key == teamMember.NameKey)
                                                                                      .ToListAsync();

                    IEnumerable<Text> surnameTextAllLanguage = await lawyerDbContext.Texts
                                                                                       .Where(m => m.Key == teamMember.SurnameKey)
                                                                                           .ToListAsync();

                    IEnumerable<Text> descriptionTextAllLanguage = await lawyerDbContext.Texts
                                                                                            .Where(m => m.Key == teamMember.DescriptionKey)
                                                                                               .ToListAsync();

                    //Update texts all language for properties
                    foreach (var item in TeamMembers)
                    {
                        Text name = nameTextAllLanguage.SingleOrDefault(m => m.LanguageId == item.LanguageId);
                        name.TextContent = item.Name;
                        Text surname = surnameTextAllLanguage.SingleOrDefault(m => m.LanguageId == item.LanguageId);
                        surname.TextContent = item.Surname;
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

                    ModelState.AddModelError("", "Some error occured !!!");
                }
                finally
                {
                    if (transaction != null)
                        transaction.Dispose();
                }
            }

            TeamMemberEditModel teamMemberEditModel = new TeamMemberEditModel
            {
                Id = id,
                TeamMembers = TeamMembers,
                Img = null,
                Languages = await lawyerDbContext.Languages
                                                      .AsNoTracking()
                                                            .ToListAsync(),
                Areas = (await lawyerDbContext.GetAreaViewAsync())
                                                  .Where(m => m.LanguageId == DbContextService.GetLanguageIdByShortName(lawyerDbContext)).ToList(),
                AreaId = lawyerDbContext.TeamToAreas.Where(m => m.TeamMemberId == id).Select(m => m.AreaId).ToList()

        };

            return View(teamMemberEditModel);

        }

        [HttpPost]
        public async Task<IActionResult> Delete([Required][FromForm] int id)
        {
            if (ModelState.IsValid)
            {
                //Begin transaction for delete
                IDbContextTransaction transaction = null;
                try
                {
                    transaction = await lawyerDbContext.Database.BeginTransactionAsync();

                    TeamMember teamMember = await lawyerDbContext.TeamMembers.FindAsync(id);

                    if (teamMember == null)
                        throw new NullReferenceException();

                    //Remove member datas
                    lawyerDbContext.Texts.RemoveRange(lawyerDbContext.Texts.Where(m => m.Key == teamMember.NameKey));
                    lawyerDbContext.Texts.RemoveRange(lawyerDbContext.Texts.Where(m => m.Key == teamMember.SurnameKey));
                    lawyerDbContext.Texts.RemoveRange(lawyerDbContext.Texts.Where(m => m.Key == teamMember.DescriptionKey));
                    lawyerDbContext.TeamMembers.Remove(teamMember);

                    await lawyerDbContext.SaveChangesAsync();

                    FileService.DeleteFile(teamMember.Img, "Uploads");

                    transaction.Commit();

                    return Json(new
                    {
                        status = HttpStatusCode.OK
                    });
                }

                catch
                {
                    transaction.Rollback();
                }

                finally
                {
                    if (transaction != null)
                        transaction.Dispose();
                }
            }

            return Json(new
            {
                NotFound=HttpStatusCode.NotFound
            });
        }

        [HttpGet]
        public async Task<IActionResult> Details([Required][FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TeamMemberDetailModel teamMembeDetailModel = new TeamMemberDetailModel();

                    teamMembeDetailModel.TeamMemberViews = (await lawyerDbContext.GetTeamMembersViewAsync())
                                                                                             .Where(m => m.Id == id)
                                                                                                 ?.OrderBy(m => m.LanguageId);
                    teamMembeDetailModel.Languages = await lawyerDbContext.Languages
                                                                               .AsNoTracking()
                                                                                    .ToListAsync();

                    string areaNameKey = lawyerDbContext.TeamToAreas.Include<TeamToArea>("Area")
                                                                .FirstOrDefault(m => m.TeamMemberId == id)
                                                                      ?.Area.NameKey;

                    teamMembeDetailModel.Area = lawyerDbContext.Texts
                                                                 .SingleOrDefault(m => m.Key == areaNameKey &&
                                                                                       m.LanguageId == DbContextService.GetLanguageIdByShortName(lawyerDbContext, "en-US"))
                                                                                              ?.TextContent;

                    return View(teamMembeDetailModel);
                }
                catch { }
                
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Linq;
using System.Resources;
using LawyerApp.Models;
using System.Threading.Tasks;
using LawyerApp.Infrastructures;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Net;

namespace LawyerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<SharedResource> stringLocalizer;
        private readonly LawyerDbContext lawyerDbContext;

        public HomeController(IStringLocalizer<SharedResource> stringLocalizer , LawyerDbContext lawyerDbContext)
        {
            this.stringLocalizer = stringLocalizer;
            this.lawyerDbContext = lawyerDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromRoute] string culture)
        {
            IndexViewModel indexViewModel = null;
            try
            {
                int? languageId = DbContextService.GetLanguageIdByShortName(lawyerDbContext, culture);

                if (languageId == null)
                    return NotFound();

                indexViewModel = new IndexViewModel
                {
                    Sliders = await lawyerDbContext.Sliders.ToListAsync(),

                    Areas = (await lawyerDbContext.GetAreaViewAsync())
                                                     .Where(m => m.LanguageId == languageId)
                                                        .ToList(),

                    Contact = (await lawyerDbContext.GetContactViewAsync())
                                                         .SingleOrDefault(m => m.LanguageId == languageId),

                    TeamService = (await lawyerDbContext.GetTeamServicesViewAsync())
                                                          .SingleOrDefault(m => m.LanguageId == languageId)
                };
            }
            catch 
            {
                return NotFound();
            }

            return View(indexViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Firm([FromRoute] string culture)
        {
            FırmViewModel firmViewModel = null;
            try
            {
                StaticData staticData = await lawyerDbContext.StaticDatas.SingleOrDefaultAsync();

                int? languageId = DbContextService.GetLanguageIdByShortName(lawyerDbContext, culture);

                if (languageId == null)
                    return NotFound();

                var firm = (await lawyerDbContext.GetFirmViewAsync()).SingleOrDefault(m => m.LanguageId == languageId);

                firmViewModel = new FırmViewModel
                {
                    Title = firm.Title,
                    Description = firm.Description,
                    Img = firm.Img
                };
               
            }
            catch
            {
                return NotFound();
            }

            return View(firmViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Practice([FromRoute] string culture)
        {
            try
            {
                int? languageId = DbContextService.GetLanguageIdByShortName(lawyerDbContext, culture);

                if (languageId == null)
                    return NotFound();

                var areas = (await lawyerDbContext.GetAreaViewAsync()).Where(m => m.LanguageId == languageId);

                return View(areas);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Contact([FromRoute] string culture)
        {
            int? languageId = DbContextService.GetLanguageIdByShortName(lawyerDbContext, culture);

            if (languageId == null)
                return NotFound();

            try
            {
                var contact = (await lawyerDbContext.GetContactViewAsync()).SingleOrDefault(m => m.LanguageId == languageId);

                ContactsViewModel contactsViewModel = new ContactsViewModel
                {
                    Email = contact.ContactEmail,
                    Number = contact.ContactNumber,
                    Address = contact.ContactAdress
                };

                return View(contactsViewModel);
            }
            catch 
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact([FromRoute] string culture, MessageSendModel Message)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await lawyerDbContext.Messages.AddAsync(new Message
                    {
                         Email= Message.Email,
                         Name= Message.Name,
                         MessageContent= Message.Message,
                         Subject= Message.Subject,
                    });
                    await lawyerDbContext.SaveChangesAsync();

                    return RedirectToAction(nameof(Contact));
                }
                catch
                {
                    return BadRequest();
                }
                
            }

            try
            {
                int? languageId = DbContextService.GetLanguageIdByShortName(lawyerDbContext, culture);

                if (languageId == null)
                    return NotFound();

                var contact = (await lawyerDbContext.GetContactViewAsync()).SingleOrDefault(m => m.LanguageId == languageId);

                ContactsViewModel contactsViewModel = new ContactsViewModel
                {
                    Email = contact.ContactEmail,
                    Number = contact.ContactNumber,
                    Address = contact.ContactAdress
                };
                return View(contactsViewModel);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Services([FromRoute] string culture)
        {
            try
            {
                int? languageId = DbContextService.GetLanguageIdByShortName(lawyerDbContext, culture);

                if (languageId == null)
                    return NotFound();

                var services = (await lawyerDbContext.GetAreaViewAsync()).Where(m => m.LanguageId == languageId);
                return View(services);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Service([FromRoute] string culture, [Required][FromRoute]int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int? languageId = DbContextService.GetLanguageIdByShortName(lawyerDbContext, culture);

                    if (languageId == null)
                        return NotFound();

                    var service = (await lawyerDbContext.GetAreaViewAsync()).SingleOrDefault(m => m.LanguageId == languageId && m.Id == id);

                    return View(service);
                }
                catch { } 
                
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Team([FromRoute] string culture)
        {
            try
            {
                int? languageId = DbContextService.GetLanguageIdByShortName(lawyerDbContext, culture);

                if (languageId == null)
                    return NotFound();

                var teamMembers = (await lawyerDbContext.GetTeamMembersViewAsync()) 
                                                             .Where(m => m.LanguageId == languageId);

                return View(teamMembers);
            }
            catch 
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Error(int id)
        {
            ViewBag.statusCode = id;
            return View();
        }
    }
}
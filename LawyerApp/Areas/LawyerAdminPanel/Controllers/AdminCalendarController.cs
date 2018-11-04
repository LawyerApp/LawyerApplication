using LawyerApp.Areas.LawyerAdminPanel.Models;
using LawyerApp.Infrastructures;
using LawyerApp.Infrastructures.File;
using LawyerApp.Models;
using LawyerApp.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LawyerApp.Areas.LawyerAdminPanel.Controllers
{
    [Area(nameof(LawyerAdminPanel))]
    public class AdminCalendarController : Controller
    {
        private readonly LawyerDbContext _context;
        private readonly IMemoryCache _cache;
        private readonly EmailService _service;
        public AdminCalendarController(LawyerDbContext context, IMemoryCache cache, EmailService service)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                int? languageId = DbContextService.GetLanguageIdByShortName(_context);
                IEnumerable<TeamMemberDto> teamMembers = await _context.GetTeamMembersViewAsync();

                WeekDaysKeyValue weekDaysKeyValue = new WeekDaysKeyValue();
                weekDaysKeyValue = await ReadAndWriteFile.ReadFileAsync<WeekDaysKeyValue>(Environment.CurrentDirectory + @"\wwwroot\Data\weekDays.json");

                return View(new CalendarIndexViewModel
                {
                    teamMembers = teamMembers.Where(m => m.LanguageId == languageId),
                    weekDaysKeyValue = weekDaysKeyValue
                }
                );
            }
            catch (Exception)
            {
                return Redirect(nameof(Index));
            }
        }

        public async Task<IActionResult> configuredays(string weekday)
        {
            try
            {
                WeekDaysKeyValue weekDaysKeyValue = new WeekDaysKeyValue();
                weekDaysKeyValue = await ReadAndWriteFile.ReadFileAsync<WeekDaysKeyValue>(Environment.CurrentDirectory + @"\wwwroot\Data\weekDays.json");
                bool a = true;
                if (weekDaysKeyValue.weekDays.ContainsKey(weekday))
                {
                    string value = weekDaysKeyValue.weekDays[weekday];
                    if (value == "true")
                    {
                        weekDaysKeyValue.weekDays[weekday] = "false";
                        a = false;
                    }
                    else
                    {
                        weekDaysKeyValue.weekDays[weekday] = "true";
                        a = true;
                    }
                    await ReadAndWriteFile.WriteFileAsync<WeekDaysKeyValue>(weekDaysKeyValue, Environment.CurrentDirectory + @"\wwwroot\Data\weekDays.json");
                }
                return Json(a);
            }
            catch (Exception)
            {
                return View(nameof(Index));
            }
        }

        public async Task<IActionResult> configureLimit(int day)
        {
            try
            {
                if (day != 0)
                {
                    var data = await ReadAndWriteFile.ReadFileAsync<WeekDaysKeyValue>(Environment.CurrentDirectory + @"\wwwroot\Data\weekDays.json");
                    data.limit = day;
                    await ReadAndWriteFile.WriteFileAsync<WeekDaysKeyValue>(data, Environment.CurrentDirectory + @"\wwwroot\Data\weekDays.json");
                    return Json(day);
                }
                else
                    return Json(HttpStatusCode.NotFound);
            }
            catch (Exception)
            {
                return View(nameof(Index));
            }

        }

        public async Task<IActionResult> GetweekDays([FromQuery]DateTime date)
        {
            try
            {
                WeekDaysKeyValue weekDaysKeyValue = await ReadAndWriteFile.ReadFileAsync<WeekDaysKeyValue>(Environment.CurrentDirectory + @"\wwwroot\Data\weekDays.json");
                List<DateTime> dates = await _context.Holidays.Where(m => m.Date.Year == date.Year && m.Date.Month == date.Month).Select(x => x.Date).ToListAsync();
                return Json(new CalendarDayViewModel
                {
                    weekDays = weekDaysKeyValue.weekDays,
                    Dates = dates
                });
            }
            catch (Exception)
            {
                return View(nameof(Index));
            }
        }

        public async Task<IActionResult> noteHoliday([FromQuery]DateTime dt)
        {
            try
            {
                var holiday = await _context.Holidays.Where(m => m.Date.Year == dt.Year && m.Date.Month == dt.Month && m.Date.Day == dt.Day).FirstOrDefaultAsync();
                if (holiday != null)
                    _context.Holidays.Remove(holiday);
                else
                    await _context.Holidays.AddAsync(new Holiday
                    {
                        Date = dt
                    });
                await _context.SaveChangesAsync();
                return Json(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return View(nameof(Index));
            }
        }

        public IActionResult TeammembersConfiguration(int id)
        {
            try
            {
                HttpContext.Session.SetInt32("user", id);
                return View();
            }
            catch (Exception)
            {
                return Redirect("");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TeammemberSelectNotWorkings(DateTime dt)
        {
            try
            {
                int? id = HttpContext.Session.GetInt32("user");
                var tm = await _context.Schedules.Where(m => m.TeammemberId == id && m.Date.Year == dt.Year && m.Date.Month == dt.Month && m.Date.Day == dt.Day).ToListAsync();
                var teamMember = await _context.TeamMembers.FindAsync(id);
                return Json(new
                {
                    schedules = tm.Select(x => new { name = x.Name, surname = x.Surname, email = x.Email, date = x.Date, accept = x.Acceept, workDay = x.WorkOrNot }),
                    begin = teamMember.Begin,
                    end = teamMember.End
                });
            }
            catch (Exception)
            {
                return View(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SechuduleDay(DateTime date)
        {
            int id = (int)HttpContext.Session.GetInt32("user");
            var schedule = await _context.Schedules.Where(x => x.Date == date && x.WorkOrNot == false).FirstOrDefaultAsync();
            if (schedule == null)
            {
                ///mail message
                await _context.Schedules.AddAsync(new Schedule
                {
                    Date = date,
                    TeammemberId = id,
                    WorkOrNot = false,
                    Name = " ",
                    Surname = " "
                });
                await _context.SaveChangesAsync();
                return Json(200);
            }
            else
            {

                _context.Schedules.Remove(schedule);
                await _context.SaveChangesAsync();
                return Json(201);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AcceptOrNot(DateTime date)
        {
            var schedules = await _context.Schedules.Where(x => x.Date == date && x.WorkOrNot == true).FirstOrDefaultAsync();
            if (schedules.Acceept == true)
            {
                //await _service.SendMailAsync(schedules.Email, "sdadasd", "your reserve declined");
                _context.Schedules.Remove(schedules);
                await _context.SaveChangesAsync();
                return Json(200);
            }
            else
            {
                //await _service.SendMailAsync(schedules.Email, "sdadasd", "your reserve accepted");
                schedules.Acceept = true;
                await _context.SaveChangesAsync();
                return Json(201);
            }

        }
    }
}

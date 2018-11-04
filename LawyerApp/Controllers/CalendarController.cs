using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LawyerApp.Infrastructures.Exceptions;
using LawyerApp.Infrastructures.File;
using LawyerApp.Models;
using LawyerApp.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

namespace LawyerApp.Controllers
{
    public class CalendarController : Controller
    {
        private readonly LawyerDbContext _context;
        public CalendarController(LawyerDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int Id)
        {
            try
            {
                int id = await _context.TeamToAreas.Where(m => m.AreaId == Id).Select(m => m.TeamMemberId).FirstOrDefaultAsync();
                HttpContext.Session.SetInt32("user", id);
            }
            catch {}
            return View();
        }

        public async Task<IActionResult> GetWeekDaysAndHolidays([FromRoute] string culture,[FromQuery]DateTime date)
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
                    schedules =tm.Select(x => new { name = x.Name, surname = x.Surname, email = x.Email, date = x.Date, accept = x.Acceept, workDay = x.WorkOrNot }),
                    begin = teamMember.Begin,
                    end = teamMember.End
                });
            }
            catch (Exception ex)
            {
                return View(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NoteAndCheckDate([FromRoute]string culture,DateTime date)
        {
            WeekDaysKeyValue weekDaysKeyValue=new WeekDaysKeyValue();
            try
            {
                weekDaysKeyValue = await ReadAndWriteFile.ReadFileAsync<WeekDaysKeyValue>(Environment.CurrentDirectory + @"\wwwroot\Data\weekDays.json");
                int count = 0;
                if ((date - DateTime.Now).Days <= weekDaysKeyValue.limit && date > DateTime.Now)
                {
                    foreach (var item in weekDaysKeyValue.weekDays)
                    {
                        count++;
                        if (count == ((int)date.DayOfWeek+1))
                        {
                            if (item.Value.ToLower() == "true")
                            {
                                int? userId = HttpContext.Session.GetInt32("user");
                                var holiday = await _context.Holidays.Where(m => m.Date.Year == date.Year && m.Date.Month == date.Month && m.Date.Day == date.Day).FirstOrDefaultAsync();
                                if (holiday != null)
                                    throw new WeekDayException("this day is holiday");
                                var lawyer = await _context.Schedules.Where(m => m.TeammemberId == userId && m.Date == date).FirstOrDefaultAsync();
                                if (lawyer != null)
                                    throw new WeekDayException("Lawyer is busyu this time");
                                HttpContext.Session.SetString("date",date.ToString());
                                return Json(200);
                            }
                            else
                                throw new WeekDayException("we dont have time");
                        }
                        continue;
                    }
                }
                else
                    throw new WeekDayException($"you cannot select {weekDaysKeyValue.limit}");
                throw new WeekDayException("we dont have time");
            }
            catch (WeekDayException ex)
            {
                return Json(ex.Message);
            }
            catch (Exception)
            {
                return Json("something went wrong please try again later");
            }
        }

        public IActionResult ScheduleDay()
        {
            string date = HttpContext.Session.GetString("date");
            if (date == null)
                return View(nameof(Index));
            else
                return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ScheduleDay(ScheduleViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int teamId = Convert.ToInt32(HttpContext.Session.GetInt32("user"));
                    DateTime date = Convert.ToDateTime(HttpContext.Session.GetString("date"));
                    var schedule = new Schedule
                    {
                        Name = model.Name,
                        Surname = model.Surname,
                        Message = model.Message,
                        Email=model.Email,
                        Phone = model.Phone,
                        TeammemberId = teamId,
                        Date = date
                    };
                    await _context.Schedules.AddAsync(schedule);
                    await _context.SaveChangesAsync();
                    return View(nameof(Result));
                }
                catch (Exception)
                {
                    return View();
                }
            }
            return View();
        }

        public IActionResult Result()
        {
            return View();
        }
    }
}
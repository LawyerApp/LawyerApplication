using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Models.ViewModels
{
    public class CalendarDayViewModel
    {
        public Dictionary<string, string> weekDays { get; set; }
        public List<DateTime> Dates { get; set; }
    }
}

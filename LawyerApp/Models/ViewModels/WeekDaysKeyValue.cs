using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Models.ViewModels
{
    public class WeekDaysKeyValue
    {
        public Dictionary<string, string> weekDays { get; set; }
        public int limit { get; set; }
    }
}

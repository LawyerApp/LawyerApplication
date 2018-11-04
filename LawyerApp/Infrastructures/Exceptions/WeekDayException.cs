using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Infrastructures.Exceptions
{
    public class WeekDayException: ApplicationException
    {
        public WeekDayException() { }

        public WeekDayException(string message) : base(message) { }

        public WeekDayException(string message, Exception inner) : base(message, inner) { }
    }
}

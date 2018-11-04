using LawyerApp.Models.ViewModels;
using System.Collections.Generic;

namespace LawyerApp.Areas.LawyerAdminPanel.Models
{
    public class CalendarIndexViewModel
    {
       public IEnumerable<TeamMemberDto> teamMembers;
       public WeekDaysKeyValue weekDaysKeyValue { get; set; }
    }
}

using LawyerApp.Models;
using System.Collections.Generic;

namespace LawyerApp.Areas.LawyerAdminPanel.Models
{
    public class TeamMemberDetailModel
    {
        public IEnumerable<TeamMemberDto> TeamMemberViews { get; set; }
        public IEnumerable<Language> Languages { get; set; }
        public string Area { get; set; }
    }
}

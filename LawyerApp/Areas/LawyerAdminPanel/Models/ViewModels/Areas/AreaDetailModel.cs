using LawyerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Areas.LawyerAdminPanel.Models
{
    public class AreaDetailModel
    {
        public IEnumerable<AreaDto> Areas { get; set; }
        public IEnumerable<Language> Languages { get; set; }
        public byte MeetingMinute { get; set; }
    }
}

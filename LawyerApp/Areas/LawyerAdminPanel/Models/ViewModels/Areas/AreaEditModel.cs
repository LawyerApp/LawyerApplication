using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Areas.LawyerAdminPanel.Models
{
    public class AreaEditModel
    {
        public List<AreaMap> Areas { get; set; }
        public byte MeetingMinute { get; set; }
    }
}

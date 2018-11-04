using LawyerApp.Areas.LawyerAdminPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Models
{
    public class IndexViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<AreaDto> Areas { get; set; }
        public TeamServicesDto TeamService { get; set; }
        public ContactDto Contact { get; set; }
    }
}

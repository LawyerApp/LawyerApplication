using LawyerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Areas.LawyerAdminPanel.Models
{
    public class AboutViewModel
    {
        public int Id { get; set; }
        public List<AboutMap> TeamServices { get; set; }
        public List<Language> Languages { get; set; }
    }
}

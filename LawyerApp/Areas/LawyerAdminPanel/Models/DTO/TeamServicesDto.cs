using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Areas.LawyerAdminPanel.Models
{
    public class TeamServicesDto
    {
        public int Id { get; set; }
        [Display(Name ="Our team description")]
        public string TeamDescription { get; set; }
        [Display(Name ="Our services description")]
        public string ServicesDescription { get; set; }
        public int LanguageId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Areas.LawyerAdminPanel.Models
{
    public class ContactDto
    {
        public int Id { get; set; }
        [Display(Name ="Phone Number")]
        public string ContactNumber { get; set; }
        [Display(Name = "Home Number")]
        public string ContactHomeNumber { get; set; }
        [Display(Name ="Email")]
        public string ContactEmail { get; set; }
        [Display(Name ="Adress")]
        public string ContactAdress { get; set; }
        public int LanguageId { get; set; }
    }
}

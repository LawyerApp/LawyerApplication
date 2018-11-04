using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Areas.LawyerAdminPanel.Models
{
    public class FirmDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Img { get; set; }
        public string Description { get; set; }
        public int LanguageId { get; set; }
    }
}

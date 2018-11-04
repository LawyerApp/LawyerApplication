using LawyerApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LawyerApp.Areas.LawyerAdminPanel.Models
{
    public class AreaViewModel
    {
        public int Id { get; set; }
        public List<AreaMap> Areas { get; set; }
        [Required(ErrorMessage ="The meeting minute field is required.")]
        public byte MeetingMinute { get; set; }
        public List<Language> Languages { get; set; }
    }
}

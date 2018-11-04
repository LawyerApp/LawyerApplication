using System.ComponentModel.DataAnnotations;

namespace LawyerApp.Areas.LawyerAdminPanel.Models
{
    public class AboutMap
    {
        [Required]
        [StringLength(maximumLength:2000)]
        public string OurTeamDescription { get; set; }
        [Required]
        [StringLength(maximumLength: 2000)]
        public string OurServicesDescription { get; set; }
        public int LanguageId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace LawyerApp.Areas.LawyerAdminPanel.Models
{
    public class FirmMap
    {
        [Required]
        [StringLength(maximumLength:2000)]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: 4000)]
        public string Description { get; set; }
        public int LanguageId { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace LawyerApp.Areas.LawyerAdminPanel.Models
{
    public class ContactMap
    {
        [Required(ErrorMessage ="The adress field is required.")]
        [StringLength(maximumLength:2000)]
        [Display(Name ="Address")]
        public string ContactAdress { get; set; }
        public int LanguageId { get; set; }
    }
}

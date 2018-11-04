using LawyerApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LawyerApp.Areas.LawyerAdminPanel.Models
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        public List<ContactMap> ContactAdresses { get; set; }

        [Required(ErrorMessage = "The phone number field is required.")]
        [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", ErrorMessage = "Please enter a valid phone number.")]
        [Display(Name = "Phone Number")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "The email field is required.")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Please enter a valid email.")]
        [Display(Name = "Email")]
        public string ContactEmail { get; set; }

        public List<Language> Languages { get; set; }
    }
}

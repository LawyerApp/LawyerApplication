using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Models.ViewModels
{
    public class ScheduleViewModel
    {
        [Required(ErrorMessage = "RequiredName")]
        [MinLength(3)]
        public string Name { get; set; }

        [MinLength(3)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "RequiredEmail")]
        [StringLength(maximumLength:50,ErrorMessage = "MaxLengthEmail")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",ErrorMessage ="CheckEmail")]
        public string Email { get; set; }

        [RegularExpression(@"(([+]\d{1,3}) ([0-9 ]{0,14}))",ErrorMessage = "CheckPhoneNumber")]
        public string Phone { get; set; }

        [MinLength(30)]
        public string Message { get; set; }
    }
}

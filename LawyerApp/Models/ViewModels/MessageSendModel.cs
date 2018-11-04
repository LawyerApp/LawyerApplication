using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Models
{
    public class MessageSendModel
    {
        [Required(ErrorMessage ="RequiredName")]
        [StringLength(maximumLength:50, ErrorMessage ="MaxLengthName")]
        public string Name { get; set; }
        [Required(ErrorMessage = "RequiredEmail")]
        [StringLength(maximumLength: 50, ErrorMessage = "MaxLengthEmail")]
        public string Email { get; set; }
        [StringLength(maximumLength: 255, ErrorMessage = "MaxLengthSubject")]
        public string Subject { get; set; }
        [Required(ErrorMessage ="RequiredMessage")]
        [StringLength(maximumLength:500,ErrorMessage = "MaxLengthMessage")]
        public string Message { get; set; }
    }
}

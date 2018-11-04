using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace LawyerApp.Areas.LawyerAdminPanel.Models
{
    public class SliderCreateModel
    {
        [Required]
        public IFormFile Img { get; set; }
    }
}

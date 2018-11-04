using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Areas.LawyerAdminPanel.Models
{
    public class SliderEditModel
    {
        public int Id { get; set; }
        [Required]
        public IFormFile Img { get; set; }
        public string FileName { get; set; }
    }
}

using LawyerApp.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace LawyerApp.Areas.LawyerAdminPanel.Models
{
    public class FirmViewModel
    {
        public int Id { get; set; }

        public List<FirmMap> Firms { get; set; }

        public IFormFile Img { get; set; }

        public List<Language> Languages { get; set; }
    }
}

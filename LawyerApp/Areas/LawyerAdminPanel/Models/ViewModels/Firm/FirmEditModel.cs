using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace LawyerApp.Areas.LawyerAdminPanel.Models
{
    public class FirmEditModel
    {
        public IFormFile Img { get; set; }
        public List<FirmMap> Firms { get; set; }
    }
}

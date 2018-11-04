using LawyerApp.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LawyerApp.Areas.LawyerAdminPanel.Models
{
    public class TeamMemberViewModel
    {
        public List<TeamMemberCreateModel> TeamMembers { get; set; }
        [Required]
        public IFormFile Img { get; set; }
        [Required]
        public int AreaId { get; set; }
        [Required]
        public byte Begin { get; set; }
        [Required]
        public byte End { get; set; }
        public List<Language> Languages { get; set; }
        public List<AreaDto> Areas { get; set; }
    }
}

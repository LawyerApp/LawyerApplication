using LawyerApp.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LawyerApp.Areas.LawyerAdminPanel.Models
{
    public class TeamMemberEditModel
    {
        public int Id { get; set; }
        public List<TeamMemberCreateModel> TeamMembers { get; set; }
        [Required(ErrorMessage ="The Area field is required .")]
        public List<int> AreaId { get; set; }
        public IFormFile Img { get; set; }
        [Required]
        public byte Begin { get; set; }
        [Required]
        public byte End { get; set; }
        public List<Language> Languages { get; set; }
        public List<AreaDto> Areas { get; set; }
    }
}

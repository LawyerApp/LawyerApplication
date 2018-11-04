using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Areas.LawyerAdminPanel.Models
{
    public class TeamMemberDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public int LanguageId { get; set; }
        public string Img { get; set; }
        public byte Begin { get; set; }
        public byte End { get; set; }
    }
}

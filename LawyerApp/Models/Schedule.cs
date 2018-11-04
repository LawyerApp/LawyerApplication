using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Models
{
    public class Schedule
    {
        public Guid Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        [MinLength(30)]
        public string Message { get; set; }

        [Required]
        public bool WorkOrNot { get; set; }

        [Required]
        public bool Acceept { get; set; }

        public string Email { get; set; }

        public int TeammemberId { get; set; }
        public TeamMember Teammember { get; set; }
    }
}

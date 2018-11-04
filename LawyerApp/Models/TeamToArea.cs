using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Models
{
    public class TeamToArea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Area Area { get; set; }
        [Required]
        public int AreaId { get; set; }
        public TeamMember TeamMember { get; set; }
        [Required]
        public int TeamMemberId { get; set; }
    }
}

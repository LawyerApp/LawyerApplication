using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Models
{
    [Table("TeamMembers")]
    public class TeamMember
    {
        public TeamMember()
        {
            TeamToAreas = new HashSet<TeamToArea>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:50)]
        public string NameKey { get; set; }
        [Required]
        [StringLength(maximumLength:50)]
        public string SurnameKey { get; set; }
        [Required]
        [StringLength(maximumLength:50)]
        public string DescriptionKey { get; set; }
        [Required]
        [StringLength(maximumLength:50)]
        public string Img { get; set; }
        [Required]
        public byte Begin { get; set; }
        [Required]
        public byte End { get; set; }

        public ICollection<TeamToArea> TeamToAreas { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}

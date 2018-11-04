using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Models
{
    [Table("Areas")]
    public class Area
    {
        public Area()
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
        public string DescriptionKey { get; set; }
        public byte MeetingMinute { get; set; }
        public ICollection<TeamToArea> TeamToAreas { get; set; }
    }
}

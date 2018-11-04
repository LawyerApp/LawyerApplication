using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Models
{
    [Table("StaticDatas")]
    public class StaticData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:15)]
        public string ContactNumber { get; set; }
        [Required]
        [StringLength(maximumLength:50)]
        public string ContactEmail { get; set; }
        [Required]
        [StringLength(maximumLength:50)]
        public string ContactAdressKey { get; set; }
        [Required]
        [StringLength(maximumLength:50)]
        public string OurTeamDescriptionKey { get; set; }
        [Required]
        [StringLength(maximumLength:50)]
        public string ServicesDescriptionKey { get; set; }
        [Required]
        [StringLength(maximumLength:50)]
        public string OurFirmTitleKey { get; set; }
        [Required]
        [StringLength(maximumLength:50)]
        public string OurFirmDescriptionKey { get; set; }
        [Required]
        [StringLength(maximumLength:50)]
        public string OurFirmImg { get; set; }
    }
}

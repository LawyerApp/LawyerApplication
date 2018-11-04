using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Models
{
    [Table("Languages")]
    public class Language
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:10)]
        public string LangShort { get; set; }
        [Required]
        [StringLength(maximumLength:25)]
        public string LangLong { get; set; }
    }
}

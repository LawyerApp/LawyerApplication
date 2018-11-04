using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerApp.Models
{
    [Table("Texts")]
    public class Text
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [StringLength(maximumLength:50)]
        public string Key { get; set; }
        [Required]
        public string TextContent { get; set; }
        public Language Language { get; set; }
        [Required]
        public int LanguageId { get; set; }
    }
}

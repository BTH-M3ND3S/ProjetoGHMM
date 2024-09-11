using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaGHMM.Models
{
    [Table("Setor")]
    public class SetorModel
    {
        [Key]
        [Column("SetorId")]
        public int Id { get; set; }

        [Column("SetorNome")]
        [Display(Name = "Setor")]
        [Required]
        public string SetorNome { get; set; } = string.Empty;
    }
}

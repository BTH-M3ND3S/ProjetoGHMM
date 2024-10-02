using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaGHMM.Models
{
    [Table("Fabricante")]
    public class FabricanteModel
    {
        [Key]
        [Column("FabricanteId")]
        public int Id { get; set; }

        [Column("FabricanteNome")]
        [Display(Name = "Nome do Fabricante")]
        [Required]
        public string FabricanteNome { get; set; } = string.Empty;

    }
}

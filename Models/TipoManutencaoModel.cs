using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGHMM.Models
{
    [Table("TipoManutencao")]
    public class TipoManutencaoModel
    {
        [Key]
        [Column("TipoManutencaoId")]
        public int Id { get; set; }

        [Column("TipoManutencaoNome")]
        [Display(Name = "Nome do tipo de manutencao")]
        [Required]
        public string TipoManutencaoNome { get; set; } = string.Empty;
    }
}

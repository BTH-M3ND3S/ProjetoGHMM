using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaGHMM.Models
{
    public class TipoMaquinaModel
    {
        [Key]
        [Column("TipoMaquinaId")]
        public int Id { get; set; }

        [Column("TipoMaquinaNome")]
        [Display(Name = "Tipo de máquina")]
        [Required]
        public string TipoMaquinaNome { get; set; } = string.Empty;
    }
}

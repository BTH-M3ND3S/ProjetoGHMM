using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGHMM.Models
{
    [Table("AvisoTipo")]
    public class AvisoTipoModel
    {
        [Key]
        [Column("AvisoTipoId")]
        public int Id { get; set; }

        [Column("AvisoTipoNome")]
        [Display(Name = "Nome do Aviso")]
        [Required]
        public string AvisoTipoNome { get; set; } = string.Empty;

    }
}

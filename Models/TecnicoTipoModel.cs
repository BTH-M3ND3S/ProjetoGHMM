using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaGHMM.Models
{
    [Table("TecnicoTipo")]
    public class TecnicoTipoModel
    {
        [Key]
        [Column("TecnicoTipoId")]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Column("TecnicoDescricao")]
        [Display(Name = "Descricao do Tecnico")]
        public string TecnicoTipoDescricao { get; set; } = string.Empty;
    }
}

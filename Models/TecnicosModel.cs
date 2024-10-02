using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaGHMM.Models

{
    [Table("Tecnicos")]
    public class TecnicosModel
    {

        [Key]
        [Column("TecnicosId")]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Column("TecnicoNome")]
        [Display(Name = "Nome do Tecnico")]
        public string TecnicoNome { get; set; } = string.Empty;

        [Required]
        [Column("TecnicoDetalhes")]
        [Display(Name = "Detalhes Do técnico")]
        public int TecnicoDatalhes { get; set; }

        [ForeignKey("TecnicoTipo")]
        [Column("TecnicoTipo")]
        [Display(Name = "Tipo do Tecnico")]
        public int TecnicoTipoId { get; set; }
        public TecnicoTipoModel? TecnicoTipo { get; set; }
    }
}

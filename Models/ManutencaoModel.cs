using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGHMM.Models
{
    [Table("Manutencao")]
    public class ManutencaoModel
    {
        [Key]
        [Column("ManutencaoId")]
        [Display(Name = "Cód. Manutencao")]
        public int Id { get; set; }

        [ForeignKey("TipoManutencao")]
        [Column("TipoManutencaoId")]
        [Display(Name = "Tipo de Manutenção")]

        public int TipoManutencaoId { get; set; }
        public TipoManutencaoModel? TipoManutencao { get; set; }

        [Column("ManutencaoData")]
        [Display(Name = "Data da Manutencao")]
        [Required]
        public DateTime ManutencaoData { get; set; }

        [Column("ManutencaoDescricao")]
        [Display(Name = "Descrição da Manutencao")]
        [Required]
        public string ManutencaoDescricao { get; set; } = string.Empty;

        [Column("ManutencaoCusto")]
        [Display(Name = "Custo da manutenção")]
        [Required]
        public decimal ManutencaoCusto { get; set; }

        [ForeignKey("Tecnicos")]
        [Column("Tecnicos")]
        [Display(Name = "Tecnico")]
        public int TecnicosId { get; set; }
        public TecnicosModel? Tecnicos { get; set; }



    }
}

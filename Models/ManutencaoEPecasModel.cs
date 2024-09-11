using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGHMM.Models
{
    [Table("ManutencaoEPecas")]
    public class ManutencaoEPecasModel
    {
        [Key]
        [Column("ManutencaoEPecasId")]
        [Display(Name = "Cód. Manutencao e pecas")]
        public int Id { get; set; }

        [ForeignKey("Manutencao")]
        [Column("ManutencaoId")]
        [Display(Name = "Manutencao")]
        public int ManutencaoId { get; set; }
        public ManutencaoModel? Manutencao { get; set; }

        [ForeignKey("Peca")]
        [Column("PecaId")]
        [Display(Name = "Peça")]
        public int PecaId { get; set; }
        public PecaModel? Peca { get; set; }


    }
}

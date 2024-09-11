using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGHMM.Models
{
    [Table("Peca")]
    public class PecaModel
    {
        [Key]
        [Column("PecaId")]
        public int Id { get; set; }

        [Column("PecaNome")]
        [Display(Name = "Nom da peça")]
        [Required]
        public string PecaNome { get; set; } = string.Empty;

        [Column("QuantidadeEstoque")]
        [Display(Name = "Quantidade em estoque da peça")]
        [Required]
        public int QuantidadeEstoque { get; set; } 
    }
}

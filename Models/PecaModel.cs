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
        [Display(Name = "Nome da peça")]
        [Required]
        public string PecaNome { get; set; } = string.Empty;

        [Column("QuantidadeEstoque")]
        [Display(Name = "Quantidade em estoque da peça")]
        [Required]
        public int QuantidadeEstoque { get; set; }

        [ForeignKey("Fornecedor")]
        [Column("Fornecedor")]
        [Display(Name = "Fornecedor")]
        public int FornecedorId { get; set; }
        public FornecedorModel? Fornecedor { get; set; }

        [ForeignKey("CategoriaPeca")]
        [Column("CategoriaPeca")]
        [Display(Name = "Categoria da Peca")]
        public int CategoriaPecaId { get; set; }
        public CategoriaPecaModel? CategoriaPeca { get; set; }
    }
}

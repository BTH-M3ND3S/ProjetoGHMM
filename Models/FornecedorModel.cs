using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGHMM.Models
{
    [Table("Fornecedor")]
    public class FornecedorModel
    {
        [Key]
        [Display(Name = "Cód. Fornecedor")]
        [Column("FornecedorId")]
        public int Id { get; set; }

        [Column("FornecedorNome")]
        [Display(Name = "Nome do Fornecedor")]
        [Required]
        public string FornecedorNome { get; set; } = string.Empty;

        [Column("FornecedorCnpj")]
        [Display(Name = "Cnpj do Fornecedor")]
        [Required]
        public string FornecedorCnpj { get; set; } = string.Empty;
    }
}

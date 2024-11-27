using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGHMM.Models
{
    [Table("CategoriaPeca")]
    public class CategoriaPecaModel
    {
        [Key]     
        [Column("CategoriaPecaId")]
        [Display(Name = "Cód. Categoria da peça" )]
        public int Id { get; set; }

        [Column("CategoriaPecaNome")]
        [Display(Name = "Categoria da peca")]
        [Required]
        public string CategoriaPecaNome { get; set; } = string.Empty;

        [Column("FotoUrl")]
        [Display(Name = "URL da Foto")]
        public string? FotoUrl { get; set; }

    }
}

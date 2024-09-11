using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGHMM.Models
{
    [Table("Relatorio")]
    public class RelatorioModel
    {
        [Key]
        [Column("RelatorioId")]
        [Display(Name = "Cód. Relatorio")]
        public int Id { get; set;}

        [Column("RelatorioConteudo")]
        [Display(Name = "Conteudo do relatório")]
        public string RelatorioConteudo { get; set;}    = string.Empty;

        [ForeignKey("Funcionario")]
        [Column("FuncionarioId")]
        [Display(Name = "Cód. Funcionario")]
        public int FuncionarioId { get; set; }
        public FuncionarioModel? Funcionario { get; set; }



    }
}

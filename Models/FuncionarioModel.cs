using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGHMM.Models
{
    [Table("Funcionario")]
    public class FuncionarioModel
    {
        [Key]
        [Column("FuncionarioId")]
        [Display(Name = "Cód. Funcionário")]
        public int Id { get; set; }

        [Column("FotoUrl")]
        [Display(Name = "URL da Foto")]
        public string? FotoUrl { get; set; }

        [Column("FuncionarioNome")]
        [Display(Name = "Nome do Funcionário")]
        [Required]
        public string FuncionarioNome { get; set; } = string.Empty;

        [Column("FuncionarioCpf")]
        [Display(Name = "CPF do Funcionário")]
        [Required]
        [RegularExpression(@"\d{11}", ErrorMessage = "CPF deve ter 11 dígitos")]
        public string FuncionarioCpf { get; set; } = string.Empty;

        [Column("FuncionarioEmail")]
        [Display(Name = "Email do Funcionário")]
        [Required]
        [EmailAddress]
        public string FuncionarioEmail { get; set; } = string.Empty;

        [Column("FuncionarioTelefone")]
        [Display(Name = "Telefone")]
        [Phone]
        public string FuncionarioTelefone { get; set; } = string.Empty;

        [Column("FuncionarioDataNascimento")]
        [Display(Name = "Data de Nascimento")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime FuncionarioDataNascimento { get; set; }

        [Column("FuncionarioEscolaridade")]
        [Display(Name = "Nível de Escolaridade")]
        [Required]
        public string FuncionarioEscolaridade { get; set; } = string.Empty;

        [ForeignKey("CargoId")]
        [Display(Name = "Cód. Cargo")]
        public int CargoId { get; set; }
        public CargoModel? Cargo { get; set; }

        [Column("FuncionarioSetor")]
        [Display(Name = "Setor")]
        [Required]
        public string FuncionarioSetor { get; set; } = string.Empty;

        [Column("FuncionarioSenha")]
        [Display(Name = "Senha")]
        [Required]
        [DataType(DataType.Password)]
        public string FuncionarioSenha { get; set; } = string.Empty;

    }
}

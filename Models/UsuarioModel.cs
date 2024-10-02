using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGHMM.Models
{
    [Table("Usuario")]
    public class UsuarioModel
    {
        [Key]
        [Column("UsuarioId")]
        [Display(Name = "Cód. Usuário")]
        public int Id { get; set; }

        [Column("FotoUrl")]
        [Display(Name = "URL da Foto")]
        public string? FotoUrl { get; set; }

        [Column("UsuarioNome")]
        [Display(Name = "Nome do Usuário")]
        [Required]
        public string UsuarioNome { get; set; } = string.Empty;

        [Column("UsuarioCpf")]
        [Display(Name = "CPF do Usuário")]
        [Required]
        [RegularExpression(@"\d{11}", ErrorMessage = "CPF deve ter 11 dígitos")]
        public string UsuarioCpf { get; set; } = string.Empty;

        [Column("UsuarioEmail")]
        [Display(Name = "Email do Usuário")]
        [Required]
        [EmailAddress]
        public string UsuarioEmail { get; set; } = string.Empty;

        [Column("UsuarioTelefone")]
        [Display(Name = "Telefone")]
        [Phone]
        public string UsuarioTelefone { get; set; } = string.Empty;

        [Column("UsuarioDataNascimento")]
        [Display(Name = "Data de Nascimento")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime UsuarioDataNascimento { get; set; }

        [Column("UsuarioEscolaridade")]
        [Display(Name = "Nível de Escolaridade")]
        [Required]
        public string UsuarioEscolaridade { get; set; } = string.Empty;

        [ForeignKey("CargoId")]
        [Display(Name = "Cargo")]
        public int CargoId { get; set; }
        public CargoModel? Cargo { get; set; }

        [ForeignKey("SetorId")]
        [Display(Name = "Setor")]
        [Required]
        public int SetorId { get; set; }
        public SetorModel? Setor { get; set; }

        [Column("UsuarioSenha")]
        [Display(Name = "Senha")]
        [Required]
        public string UsuarioSenha { get; set; } = string.Empty;
    }
}

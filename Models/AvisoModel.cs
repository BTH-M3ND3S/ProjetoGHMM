using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGHMM.Models
{
    [Table("Aviso")]
    public class AvisoModel
    {
        [Key]
        [Column("AvisoId")]
        public int Id { get; set; }

        [Column("AvisoConteudo")]
        [Display(Name = "Cargo do Funcionário")]
        [Required]
        public string AvisoConteudo { get; set; } = string.Empty;

        [Column("AvisoVisto")]
        [Display(Name = "Status do aviso")]
        [Required]
        public Boolean AvisoVisto { get; set; }


        [ForeignKey("Usuario")]
        [Column("Usuario")]
        [Display(Name = "Usuario destinado")]
        public int UsuarioId { get; set; }
        public UsuarioModel? Usuario { get; set; }

        [ForeignKey("AvisoTipo")]
        [Column("AvisoTipo")]
        [Display(Name = "Tipo do Aviso")]
        public int AvisoTipoId { get; set; }
        public AvisoTipoModel? AvisoTipo { get; set; }



    }
}

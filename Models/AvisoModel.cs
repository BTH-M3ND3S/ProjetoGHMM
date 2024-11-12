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
        [Display(Name = "Conteudo do Aviso")]
        [Required]
        public string AvisoConteudo { get; set; } = string.Empty;

        [Column("AvisoVisto")]
        [Display(Name = "Status do aviso")]
        [Required]
        public Boolean AvisoVisto { get; set; }


        [ForeignKey("UsuarioId")]
        [Display(Name = "Usuario")]
        public int UsuarioId { get; set; }
        public UsuarioModel? Usuario { get; set; }

        [ForeignKey("AvisoTipoId")]
        [Display(Name = "Tipo do Aviso")]
        public int AvisoTipoId { get; set; }
        public AvisoTipoModel? AvisoTipo { get; set; }



    }
}

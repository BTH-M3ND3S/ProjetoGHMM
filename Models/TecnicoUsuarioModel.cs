using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGHMM.Models
{
    [Table("TecnicoUsuario")]
    public class TecnicoUsuarioModel
    {
        [Key]
        [Column("TecnicoUsuarioId")]
        public int Id { get; set; }

        [ForeignKey("Tecnicos")]
        [Column("Tecnicos")]
        [Display(Name = "Tecnico")]
        public int TecnicosId { get; set; }
        public TecnicosModel? Tecnicos { get; set; }

        [ForeignKey("Usuario")]
        [Column("Usuario")]
        [Display(Name = "Usuario")]
        public int UsuarioId { get; set; }
        public UsuarioModel? Usuario { get; set; }
    }
}

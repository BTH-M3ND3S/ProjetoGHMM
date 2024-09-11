using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaGHMM.Models
{
    [Table("Cargo")]
    public class CargoModel
    {
        [Key]
        [Column("CargoId")]
        public int Id { get; set; }

        [Column("CargoNome")]
        [Display(Name = "Cargo do Funcionário")]
        [Required]
        public string CargoNome { get; set; } = string.Empty;

       
    }
}

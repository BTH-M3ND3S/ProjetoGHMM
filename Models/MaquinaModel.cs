using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGHMM.Models
{
    [Table("Maquina")]
    public class MaquinaModel
    {
        [Key]
        [Column("MaquinaId")]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Column("Nome")]
        [Display(Name = "Nome da Máquina")]
        public string MaquinaNome { get; set; } = string.Empty;

        [ForeignKey("TipoMaquina")]
        [Column("TipoMaquinaId")]
        [Display(Name = "Tipo de Máquina")]
        public int TipoMaquinaId { get; set; }
        public  TipoMaquinaModel? TipoMaquina { get; set; }

        [ForeignKey("Setor")]
        [Column("SetorId")]
        [Display(Name = "Setor")]
        public int SetorId { get; set; }
        public SetorModel? Setor { get; set; }

        [Required]
        [StringLength(255)]
        [Column("Modelo")]
        [Display(Name = "Modelo")]
        public string MaquinaModelo { get; set; } = string.Empty;

        [Required]
        [Column("NumeroSerie")]
        [Display(Name = "Número de Série")]
        public int MaquinaNumeroSerie { get; set; }

        [ForeignKey("Fabricante")]
        [Column("FabricanteId")]
        [Display(Name = "Fabricante")]
        public int FabricanteId { get; set; }
        public FabricanteModel? Fabricante { get; set; }

        [Required]
        [Column("DataAquisicao")]
        [Display(Name = "Data de Aquisição")]
        public DateTime MaquinaDataAquisicao { get; set; }

        [Column("FotoUrl")]
        [StringLength(1000)]
        [Display(Name = "Foto da Máquina")]
        public string MaquinaFotoUrl { get; set; } = string.Empty;

        [Column("Peso")]
        [Display(Name = "Peso")]
        public float MaquinaPeso { get; set; }

        [Column("Voltagem")]
        [Display(Name = "Voltagem")]
        public int MaquinaVoltagem { get; set; }

        [Column("MaquinaDetalhes")]
        [Display(Name = "Detalhes da Maquina")]
        public string MaquinaDetalhes { get; set; } = string.Empty;
    }
}

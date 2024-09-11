using SistemaGHMM.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SistemaGHMM.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        public DbSet<FuncionarioModel> Funcionario { get; set; } 
        public DbSet<CargoModel> Cargo { get; set; } 
        public DbSet<FabricanteModel> Fabricante { get; set; } 
        public DbSet<SetorModel> Setor { get; set; } 
        public DbSet<TipoMaquinaModel> TipoMaquina { get; set; }
        public DbSet<MaquinaModel> Maquina { get; set; } 
        public DbSet<SistemaGHMM.Models.RelatorioModel> RelatorioModel { get; set; } = default!;

       



    }
}

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
        public DbSet<UsuarioModel> Usuario { get; set; } 
        public DbSet<CargoModel> Cargo { get; set; } 
        public DbSet<FabricanteModel> Fabricante { get; set; } 
        public DbSet<SetorModel> Setor { get; set; } 
        public DbSet<TipoMaquinaModel> TipoMaquina { get; set; }
        public DbSet<MaquinaModel> Maquina { get; set; } 
        public DbSet<TipoManutencaoModel> TipoManutencao { get; set; }
        public DbSet<ManutencaoModel> Manutencao { get; set; }
        public DbSet<CategoriaPecaModel> CateogriaPeca { get; set; }
        public DbSet<FornecedorModel> Fornecedor { get; set; }
        public DbSet<ManutencaoEPecasModel> ManutencaoEPecas { get; set; }
        public DbSet<PecaModel> Peca { get; set; }
        public DbSet<TecnicosModel> Tecnicos { get; set; }
        public DbSet<TecnicoTipoModel> TecnicoTipo { get; set; }
        public DbSet<TecnicoUsuarioModel> TecnicoUsuario { get; set; }




    }
}

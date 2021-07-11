using System.Collections.Generic;
using System.Data;
using Financas.Core.Entidades;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Financas.Core
{
    
    public class EFCoreContext : DbContext
    {
        public DbSet<Papel> Papeis { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }
        public DbSet<RelatorioItem> RelatorioItens { get; set; }
        public DbSet<RelatorioFiiItem> RelatorioFiiItens { get; set; }
        public DbSet<PapelTipo> PapelTipos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //bdConn = new MySqlConnection("server=localhost;database=financas;uid=root;pwd=''");
            optionsBuilder.UseMySql(@"server=localhost;database=financas;uid=root;pwd=''");
        }
    }
}

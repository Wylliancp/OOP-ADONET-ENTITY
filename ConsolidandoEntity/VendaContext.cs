using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolidandoEntity
{
    public class VendaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }

        public VendaContext()
        {

        }   
        public VendaContext(DbContextOptions<VendaContext> options): base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LocalDB;Trusted_Connection=true;");
            }
        }
    }
}

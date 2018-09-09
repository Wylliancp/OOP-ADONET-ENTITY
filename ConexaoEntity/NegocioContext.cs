using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConexaoEntity
{
    public class NegocioContext : DbContext
       {
        public DbSet<Produto> Produtos { get; set; }

        public NegocioContext()
        {

        }
        public NegocioContext(DbContextOptions<NegocioContext> options) : base(options)
        {
                
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LocalDB;Trusted_Connection=true;");
            }
        }

    }
}

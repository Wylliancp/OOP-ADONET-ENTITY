using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Entity
{
    public class EntityContext : DbContext 
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Promocao> Promocao { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        

        //chave primaria composta
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PromocaoProduto>().HasKey(pp => new { pp.PromocaoId, pp.ProdutoId });

            modelBuilder.Entity<Endereco>().ToTable("Enderecos");
            modelBuilder.Entity<Endereco>().Property<int>("ClienteId");
            modelBuilder.Entity<Endereco>().HasKey("ClienteId");
        }

        public EntityContext()
        {

        }

        internal object GetInfrasctructure<T>()
        {
            throw new NotImplementedException();
        }

        public EntityContext(DbContextOptions<EntityContext> options): base(options)
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

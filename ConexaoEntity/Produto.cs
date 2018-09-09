using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoEntity
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public double Preco { get; set; }

        public Produto()
        {

        }
        public Produto(int id, string nome, string categoria, double preco)
        {
            this.Id = id;
            this.Nome = nome;
            this.Categoria = categoria;
            this.Preco = preco;
        }
        public Produto(string nome, string categoria, double preco)
        {
            this.Nome = nome;
            this.Categoria = categoria;
            this.Preco = preco;
        }
        public override string ToString()
        {
            return "Nome: " + this.Nome + " Categoria: " + this.Categoria + " Preco: " + this.Preco;
        }
    }
}

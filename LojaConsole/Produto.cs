using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaConsole
{
    public class Produto
    {
        public int Id { get; internal set; }
        public string Nome { get; internal set; }
        public string Categoria { get; internal set; }
        public double Preco { get; internal set; }

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
        public Produto()
        {

        }
        public override string ToString()
        {
            return "Nome: " + this.Nome;
        }
    }

}

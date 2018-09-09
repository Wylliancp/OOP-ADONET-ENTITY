using System;
using System.Collections.Generic;

namespace Entity
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public double PrecoUnitario { get; set; }
        public string Unidade { get; set; }
        public IList<PromocaoProduto> Promocoes { get; set; }
        public IList<Compra> Compras { get; set; }

        public override string ToString()
        {
            //return "Id: " + this.Id + " Nome: " + this.Nome + " Categoria: " + this.Categoria + " Preco: " + this.Preco;
            return $"Produto: {this.Id}, {this.Nome}, {this.Categoria}, {this.PrecoUnitario}";    
        }

        
    }
}
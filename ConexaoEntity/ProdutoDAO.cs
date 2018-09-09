using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoEntity
{
    public class ProdutoDAO : IDisposable, IProdutoDAO
    {
        private NegocioContext context;

        public void Adicionar(Produto produto)
        {
            context.Produtos.Add(produto);
            context.SaveChanges();
        }

        public void Atualizar(Produto produto)
        {
            context.Produtos.Update(produto);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IList<Produto> Produtos(Produto produto)
        {
            return context.Produtos.ToList();
        }

        public void Remover(Produto produto)
        {
            context.Produtos.Remove(produto);
        }
    }
}

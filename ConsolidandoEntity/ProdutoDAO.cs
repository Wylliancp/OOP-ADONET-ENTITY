using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolidandoEntity
{
    public class ProdutoDAO : IDisposable, IProdutoDAO
    {
        private VendaContext context;

        public void Adicionar(Produto obj)
        {
            context.Produtos.Add(obj);
            context.SaveChanges();
        }

        public void Atualizar(Produto obj)
        {
            context.Produtos.Update(obj);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IList<Produto> Produtos(Produto obj)
        {
            return context.Produtos.ToList();
        }

        public void Remover(Produto obj)
        {
            context.Produtos.Remove(obj);
            context.SaveChanges();
        }
    }
}

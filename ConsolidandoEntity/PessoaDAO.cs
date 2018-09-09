using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolidandoEntity
{
    public class PessoaDAO : IDisposable, IPessoaDao
    {
        private VendaContext context;

        public void Adicionar(Pessoa obj)
        {
            context.Pessoas.Add(obj);
            context.SaveChanges();
        }

        public void Atualizar(Pessoa obj)
        {
            context.Pessoas.Update(obj);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IList<Pessoa> Pessoas(Pessoa obj)
        {
            return context.Pessoas.ToList();
        }

        public void Remover(Pessoa obj)
        {
            context.Pessoas.Remove(obj);
            context.SaveChanges();
        }
    }
}

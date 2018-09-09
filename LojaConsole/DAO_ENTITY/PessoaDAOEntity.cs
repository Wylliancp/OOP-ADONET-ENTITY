using LojaConsole.INTERFACES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaConsole.DAO_ENTITY
{
    public class PessoaDAOEntity : IDisposable, IPessoaDAO
    {
        private LojaContext context;

        public void Adicionar(Pessoa pessoa)
        {
            context.Pessoa.Add(pessoa);
            context.SaveChanges();
        }

        public void Atualizar(Pessoa pessoa)
        {
            context.Pessoa.Update(pessoa);
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IList<Pessoa> Pessoas(Pessoa pessoa)
        {
            return context.Pessoa.ToList();
        }

        public void Remover(Pessoa pessoa)
        {
            context.Pessoa.Remove(pessoa);
            context.SaveChanges();
        }
    }
}

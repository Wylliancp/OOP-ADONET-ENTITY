using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaConsole.INTERFACES
{
    interface IPessoaDAO
    {

        void Adicionar(Pessoa pessoa);
        void Atualizar(Pessoa pessoa);
        void Remover(Pessoa pessoa);
        IList<Pessoa> Pessoas(Pessoa pessoa);
    }
}

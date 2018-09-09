using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolidandoEntity
{
    interface IPessoaDao
    {
        void Adicionar(Pessoa obj);
        void Remover(Pessoa obj);
        void Atualizar(Pessoa obj);
        IList<Pessoa> Pessoas(Pessoa obj);
    }
}

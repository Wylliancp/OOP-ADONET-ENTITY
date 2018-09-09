using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolidandoEntity
{
    interface IProdutoDAO
    {

        void Adicionar(Produto obj);
        void Remover(Produto obj);
        void Atualizar(Produto obj);
        IList<Produto> Produtos(Produto obj);
    }
}

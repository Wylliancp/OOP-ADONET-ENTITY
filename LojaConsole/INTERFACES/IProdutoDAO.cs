using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaConsole.INTERFACES
{
    interface IProdutoDAO
    {

        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
        void Remover(Produto produto);
        IList<Produto> Produtos(Produto produto);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoAdoNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Gravar();   
        }
        private static void Gravar()
        {

           // Produto p = new Produto("Wyllian", "nome", 2131.312);
            Produto p = new Produto("Wyllian alterado", "nomes", 2535.515);

            using (var repor = new ProdutoDAO())
            {
                //repor.Adicionar(p);

                //int idAlterado = 1002;
                //Console.WriteLine(p.Id);
                //repor.Atualizar(p, idAlterado);

                repor.Remover(p);

                IList<Produto> list = repor.Produtos();

                list.ToList();

                foreach(var item in list)
                {
                    Console.WriteLine("Nome: " + item.Nome + " categoria: " + item.Categoria + " preço: " + item.Preco + " ID: " + item.Id);
                    repor.Remover(list[3]);
                    Console.WriteLine("Nome: " + item.Nome + " categoria: " + item.Categoria + " preço: " + item.Preco + " ID: " + item.Id);
                }
                Console.ReadLine();


            }
        }
    }
}

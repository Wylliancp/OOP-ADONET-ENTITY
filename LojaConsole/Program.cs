using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new LojaContext())
            {
                var list = context.Produtos.ToList();

                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }

                var p1 = list.First();//Last;//First
                p1.Nome = "Modificado e verificando o estado, underchang ou modified";
                context.SaveChanges();

                Console.WriteLine("===============================");
                list = context.Produtos.ToList();
                foreach (var item in list)
                {
                    Console.WriteLine(item);    
                }

                Console.WriteLine("===============================");
                foreach (var estado in context.ChangeTracker.Entries())
                {
                    Console.WriteLine(estado.State);
                }
                
            }
            Console.ReadLine();
                //    GravarProduto();
                //    GravarProdutoEntity();
                //    ListaProdutosEntity();
                //    RemoverProdutosEntity();
                //    ListaProdutosEntity();
                //    AtualizaProdutosEntity();
                //    ListaProdutosEntity();
                //    Console.ReadLine();

                //}

                //private static void AtualizaProdutosEntity()
                //{
                //    using (var context = new LojaContext())
                //    {
                //        Produto primero = context.Produtos.First();
                //        primero.Nome = "Conteudo alterado!!!";
                //        primero.Categoria = "livros alterados";
                //        primero.Preco = 90.00;

                //        context.Produtos.Update(primero);
                //        context.SaveChanges();
                //    }
                //}

                //private static void RemoverProdutosEntity()
                //{
                //    using (var context = new LojaContext())
                //    {
                //        IList<Produto> produtos = context.Produtos.ToList();
                //        foreach (var item in produtos)
                //        {
                //            context.Produtos.Remove(item);
                //        }
                //        context.SaveChanges();
                //    }
                //}

                //private static void ListaProdutosEntity()
                //{
                //    using (var context = new LojaContext())
                //    {
                //        IList<Produto> produtos = context.Produtos.ToList();
                //        Console.WriteLine("Lista de produtos {0} <---> ", produtos.Count());
                //        foreach (var item in produtos)
                //        {
                //            Console.WriteLine("Nome:" + item.Nome + " Categoria: " + item.Categoria + " Preço: " + item.Preco + " Id: " + item.Id);
                //        }
                //    }
                //}

                //private static void GravarProdutoEntity()
                //{
                //    Produto produto = new Produto("programação avançados", "Livros", 80.99);
                //    Produto produto1 = new Produto("banco de dados avançados", "Livros", 110.99);
                //    Produto produto2 = new Produto("front end avançados", "Livros", 20.99);
                //    Produto produto3 = new Produto("back end", "Livros", 67.99);
                //    Produto produto4 = new Produto("analise de dados", "Livros", 160.99);
                //    using (var context = new LojaContext())
                //    {
                //        add vs addRange: addRange ganhe em performance!!!
                //        context.Produtos.AddRange(produto, produto1, produto2, produto3, produto4);
                //        context.SaveChanges();
                //    }
                //}

                //private static void GravarProduto()
                //{
                //    Produto produto = new Produto("c# avançados", "Nomes", 50.99);

                //    using (var repor = new ProdutoDAO())
                //    {
                //        repor.Adicionar(produto);
                //    }
            }
    }
}

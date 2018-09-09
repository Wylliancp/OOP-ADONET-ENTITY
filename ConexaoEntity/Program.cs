using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoEntity
{
    class Program
    {
        static void Main(string[] args)
        {
            //adicionando Entity
            using (var context = new NegocioContext())
            {
                Produto p = new Produto("Wyllian Entity", "Acesso ao BD", 900.098);
                context.Produtos.AddRange(p);
                context.SaveChanges();
                IList<Produto> lista = context.Produtos.ToList();
                foreach (var item in lista)
                {
                    Console.WriteLine("Nome: " + item.Nome + " Categoria: " + item.Categoria + " Preco: " + item.Preco + " Id: " + item.Id);
                }                
            }
            //atualizando Entity

            using(var context = new NegocioContext())
            {
                Produto n = new Produto(2005,"alterado pelo entity --saDFASDF--","atualizado",456.43);
                context.Produtos.Update(n);
                context.SaveChanges();
                IList<Produto> lista = context.Produtos.ToList();
                foreach(var item in lista)
                {
                    Console.WriteLine("Nome: " + item.Nome + " Categoria: " + item.Categoria + " Preco: " + item.Preco + " Id: " + item.Id);
                }
            }

            //deletando Entity
            using(var context = new NegocioContext())
            {
                Produto n = new Produto(2005, "alterado pelo entity --saDFASDF--", "atualizado", 456.43);
                context.Produtos.RemoveRange(n);
                context.SaveChanges();
                IList<Produto> lista = context.Produtos.ToList();
                foreach (var item in lista)
                {
                    Console.WriteLine("Nome: " + item.Nome + " Categoria: " + item.Categoria + " Preco: " + item.Preco + " Id: " + item.Id);
                }
            }
            using (var context = new NegocioContext())
            {
                IList<Produto> lista = context.Produtos.ToList();
                foreach (var itens in context.ChangeTracker.Entries())
            {
                    Console.WriteLine("-----Estados:-----" + itens.State + " <-------estaria ali" + lista);
            }

            }
            Console.ReadLine();
        }
    }
}

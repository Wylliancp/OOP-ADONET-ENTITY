using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolidandoEntity
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new VendaContext())
            {
                var pr = new Produto("I30", "Carro", 210.000);
                var pe = new Pessoa("Nome", "123.123.123-90", "1.123.123", 21, pr.Id);
              
                context.Produtos.AddRange(pr);
                
                context.SaveChanges();
                //context.AddRange(pr);
                IList<Produto> produto = context.Produtos.ToList();

                foreach (var item in produto)
                {
                    Console.WriteLine("Nome: " + item.Nome + " Categoria: " + item.Categoria + "Preco: " + item.Preco);
                }
                Console.WriteLine("------------------$$------------------$$---------------$$------------");
                //context.Pessoas.AddRange(pe);
                //context.SaveChanges();
                ControlerTodas vali = new ControlerTodas();
                var px = new Pessoa("validando pessoa 2", "123.123.123-900000", "1..123", 21, pr.Id);
                vali.Todas(px);
                IList<Pessoa> pessoa = context.Pessoas.ToList();
                foreach (var item in pessoa)
                {
                    Console.WriteLine("Nome: " + item.Nome + " Cpf: " + item.Cpf + " Rg: " + item.Rg + " Idade: " + item.Idade + "Produto" + item.produto);
                }

                Console.ReadLine();
            }
        }
    }
}

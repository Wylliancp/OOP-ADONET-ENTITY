using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entity
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new EntityContext())
            {
                var cliente = context
                    .Clientes
                    .Include(p => p.EnderecoDeEntrega)
                    .FirstOrDefault();

                Console.WriteLine($"Endereço de entrega: {cliente.EnderecoDeEntrega.Logradouro}");

                var produto = context
                    .Produtos
                    //.Include(p => p.Compras)
                    .Where(pp => pp.Id == 4)
                    .FirstOrDefault();

                context.Entry(produto)
                    .Collection(p => p.Compras)
                    .Query()
                    .Where(x => x.Preco > 0)
                    .Load();

                Console.WriteLine($"Mostrando as Compras do Produto {produto.Nome}");
                foreach (var item in produto.Compras)
                {
                    Console.WriteLine(item);
                }
            }




        }

        private static void ExibirProdutosDaPromocao()
        {
            using (var context = new EntityContext())
            {

                using (var context1 = new EntityContext())
                {
                    var promocao1 = context1
                        .Promocao
                        .Include(p => p.Produtos)
                        .ThenInclude(pp => pp.Produto)//recuperando dados M para M
                        .FirstOrDefault();//tbm
                    Console.WriteLine("\n Mostrando os produtos das promocao...");
                    foreach (var item in promocao1.Produtos)
                    {
                        Console.WriteLine(item.Produto);
                    }
                }




                ////Comprar de 6 pãos franceses
                //var paoFrances = new Produto();
                //paoFrances.Nome = "pão Frances";
                //paoFrances.PrecoUnitario = 0.4;
                //paoFrances.Unidade = "Unidade";
                //paoFrances.Categoria = "Padaria";

                //var compra = new Compra();
                //compra.Quantidade = 6;
                //compra.Produto = paoFrances;
                //compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;


            }
        }

        private static void IncluirPromocao(EntityContext context)
        {
            var promocao = new Promocao();
            promocao.Descricao = "Queima tudo janeiro 2017";
            promocao.DataInicio = new DateTime(2017, 1, 1);
            promocao.DataTermino = new DateTime(2017, 1, 31);

            var produtos = context.Produtos.Where(x => x.Categoria == "Bebidas").ToList();

            foreach (var item in produtos)
            {
                promocao.IncluiProduto(item);

            }
            context.Promocao.Add(promocao);
            ExibirEntries(context.ChangeTracker.Entries());
            context.SaveChanges();
        }

        private static void UmParaUm()
            {
                var fulano = new Cliente();
                fulano.Nome = "Falaninho de Tal";
                fulano.EnderecoDeEntrega = new Endereco()
                {
                    Numero = 12,
                    Logradouro = "Rua dos Invalidos",
                    Complemento = "Sonbrado",
                    Bairro = "Centro",
                    Cidade = "Cidade"
                };

                using (var context = new EntityContext())
                {
                    context.Clientes.Add(fulano);
                    context.SaveChanges();
                    ExibirEntries(context.ChangeTracker.Entries());
                }

            }

            private static void MuitosParaMuitos()
            {
                var p1 = new Produto() { Nome = "Suco de Laranja", Categoria = "Bebidas", PrecoUnitario = 8.79, Unidade = "Livros" };
                var p2 = new Produto() { Nome = "Cafe", Categoria = "Bebidas", PrecoUnitario = 12.79, Unidade = "gramas" };
                var p3 = new Produto() { Nome = "macarrão", Categoria = "Alimentos", PrecoUnitario = 4.79, Unidade = "gramas" };

                var promocao = new Promocao();
                promocao.Descricao = "Pascoa Feliz";
                promocao.DataInicio = DateTime.Now;
                promocao.DataTermino = DateTime.Now.AddMonths(3);

                promocao.IncluiProduto(p1);
                promocao.IncluiProduto(p2);
                promocao.IncluiProduto(p3);


                using (var context = new EntityContext())
                {
                    //context.Promocao.Add(promocao);
                    var p = context.Promocao.Find(1);
                    context.Promocao.Remove(p);
                    ExibirEntries(context.ChangeTracker.Entries()); ;
                    //context.SaveChanges();
                    //ExibirEntries(context.ChangeTracker.Entries());

                    //context.Compras.Add(compra);
                    //ExibirEntries(context.ChangeTracker.Entries());
                    //context.SaveChanges();
                    //ExibirEntries(context.ChangeTracker.Entries());

                }


                
                //    using (var context = new EntityContext())
                //    {
                //        //var produtos = context.Produtos.ToList();

                //        //ExibirEntries(context.ChangeTracker.Entries());



                //        ////var produto1 = new Produto();
                //        ////produto1.Nome = "Desifetante";
                //        ////produto1.Categoria = "limpeza";
                //        ////produto1.Preco = 2.55;

                //        ////context.Produtos.AddRange(produto1);

                //        ////ExibirEntries(context.ChangeTracker.Entries());

                //        ////context.SaveChanges();

                //        ////ExibirEntries(context.ChangeTracker.Entries());

                //        //var produto = new Produto();
                //        //produto.Nome = "Desifetante";
                //        //produto.Categoria = "limpeza";
                //        //produto.Preco = 2.55;
                //        //context.Produtos.Add(produto);

                //        //var p1 = produtos.First();
                //        //context.Produtos.Remove(p1);
                //        //ExibirEntries(context.ChangeTracker.Entries());
                //        //context.SaveChanges();
                //        //ExibirEntries(context.ChangeTracker.Entries());

                //        //var entry = context.Entry(produto);
                //        //Console.WriteLine("\n\n" + entry.Entity.ToString() + " - " + entry.State);

                //        Produto n = new Produto()
                //        {
                //            Nome = "Modificar",
                //            Categoria = "VOU MODIFICAR"
                //        };
                //        Produto n1 = new Produto()
                //        {
                //            Nome = "acesso - Modificar",
                //            Categoria = "678 --VOU MODIFICAR"
                //        };
                //        context.Produtos.Add(n);
                //        ExibirEntries(context.ChangeTracker.Entries());
                //        context.Produtos.Add(n1);
                //        context.Produtos.Remove(n);
                //        ExibirEntries(context.ChangeTracker.Entries());
                //        context.SaveChanges();

                //        ExibirEntries(context.ChangeTracker.Entries());
                //        n.Nome = "MODIFICADO";
                //        n1.Nome = "MODIFICADO =-- 678";

                //        ExibirEntries(context.ChangeTracker.Entries());
                //    }


                //    //Console.WriteLine("=================");
                //    //produtos = contexto.Produtos.ToList();
                //    //foreach (var p in produtos)
                //    //{
                //    //    Console.WriteLine(p);
                //    //}

                //    //ARAL context = new ARAL();

                //    //context.Adicionar();
                //    //context.listar();
                //    //context.Atualizar();
                //    //Console.ReadLine();
                //}
            }
            private static void ExibirEntries(IEnumerable<EntityEntry> entries)
            {
                foreach (var e in entries)
                {
                    Console.WriteLine(e.Entity.ToString() + "   " + e.State);
                }
            }
    }
}

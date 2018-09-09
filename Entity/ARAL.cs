//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Entity
//{
//    public class ARAL
//    {
//        public void Adicionar()
//        {
//            using (var context = new EntityContext())
//            {
//                Produto p = new Produto()
//                {
//                    Nome = "wyllian",
//                    Categoria = "Nome",
//                    Preco = 1.00000000
//                };
//                context.Produtos.Add(p);
//                context.SaveChanges();
//            }
//        }

//        public void Atualizar()
//        {
//            using (var context = new EntityContext())
//            {
//                Produto p = new Produto()
//                {
//                    Id = 2010,
//                    Nome = "carlos",
//                    Categoria = "Nome",
//                    Preco = 0.0
//                };
//                context.Produtos.Update(p);
//                context.SaveChanges();
//            }
//        }

//        public void Remover()
//        {
//            using (var context = new EntityContext())
//            {
//                Produto p = new Produto()
//                {
//                    Nome = "Fralda",
//                    Categoria = "Limpeza",
//                    Preco = 99.0
//                };
//                context.Produtos.Remove(p);
//                context.SaveChanges();
//            }
//        }

//        public void listar()
//        {
//            using (var context = new EntityContext())
//            {
//                IList<Produto> lista = context.Produtos.ToList();
                
//                foreach (var item in lista)
//                {

//                    Console.WriteLine("\n Nome: " + item.Nome + "\n Categoria: " + item.Categoria + "\n Preco: " + item.Preco);
                    
//                }

//                foreach (var status in context.ChangeTracker.Entries())
//                {
//                    Console.WriteLine(status.State);
//                }


//            }
                
//        }
//    }
//}

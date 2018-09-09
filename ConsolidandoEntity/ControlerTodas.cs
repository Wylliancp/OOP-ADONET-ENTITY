using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolidandoEntity
{
    public class ControlerTodas
    {
        //Simulando Dados vindo da views e tratando nesta classe.

        public void Todas(Pessoa p)
        {
            this.ValidarCpf(p.Cpf);
            this.ValidarNome(p.Nome);
            this.ValidarRg(p.Rg);
            this.ValidarIdade(p.Idade);
        }


        public void ValidarNome(string nome)
        {
            using (var context = new VendaContext())
            {

            
            if(nome != null && nome.Count() >= 3)
            {
                Pessoa p = new Pessoa();
                p.Nome = nome;
                    context.Pessoas.AddRange(p);
                    context.SaveChanges();
            }

            }
        }
        public void ValidarCpf(string cpf)
        {
            using (var context = new VendaContext())
            {

            
                if (cpf != null && cpf.Count() <= 11)
                {
                    Pessoa p = new Pessoa();
                    context.Pessoas.AddRange();
                    context.SaveChanges();
                }
            }
        }
        public void ValidarRg(string rg)
        {
            using(var context = new VendaContext())
            {

            
            if (rg != null && rg.Count() < 10)
            {
                Pessoa p = new Pessoa();
                p.Rg = rg;
                    context.Pessoas.AddRange(p);
            }
            }
        }
        public void ValidarIdade(int idade)
        {
            using(var context = new VendaContext())
            {

            
            if (idade != null && idade < 10)
            {
                Pessoa p = new Pessoa();
                p.Idade = idade;
                PessoaDAO n = new PessoaDAO();
                n.Adicionar(p);
            }
            }
        }
    }
}

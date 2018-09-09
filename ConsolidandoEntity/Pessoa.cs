using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolidandoEntity
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public int Idade { get; set; }
        public Produto produto { get; set; }

        public Pessoa()
        {

        }
        public Pessoa(int id, string nome, string cpf, string rg, int idade)
        {
            this.Id = id;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Rg = rg;
            this.Idade = idade;
        }
        public Pessoa(string nome, string cpf, string rg, int idade, int id)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Rg = rg;
            this.Idade = idade;
        }
    }
}

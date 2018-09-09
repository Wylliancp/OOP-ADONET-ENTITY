using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaConsole
{
    public class Pessoa
    {
        public int Id { get; internal set; }
        public string Nome { get; internal set; }
        public string Cpf { get; internal set; }
        public string Rg { get; internal set; }
        public int Idade { get; internal set; }
        public char sexo { get; internal set; }


        public Pessoa(int id, string nome, string cpf, string rg, int idade, char sexo)
        {
            this.Id = id;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Rg = rg;
            this.Idade = idade;
            this.sexo = sexo;
        }

        public Pessoa()
        {
        }

    }
}

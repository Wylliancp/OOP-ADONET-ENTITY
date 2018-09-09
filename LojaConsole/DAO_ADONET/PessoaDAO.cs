using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaConsole
{
    public class PessoaDAO 
    {
        private SqlConnection conexao;
        private Conexao com;
        public PessoaDAO()
        {
            this.conexao = com.conn();//new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=LocalDB;Trusted_Connection=true;");
            this.conexao.Open();
        }

        public void Dispose()
        {
            this.conexao.Close();
        }

        public void Adicionar(Pessoa pessoa)
        {
            try { 
            var insertCmd = conexao.CreateCommand();
            insertCmd.CommandText = "Insert Into Pessoa (Nome, Cpf, Rg, Idade, Sexo) values ( @nome, @cpf, @rg, @idade, @sexo ";

            var paramNome = new SqlParameter("nome", pessoa.Nome);
            insertCmd.Parameters.Add(paramNome);

            var paramCpf = new SqlParameter("cpf", pessoa.Cpf);
            insertCmd.Parameters.Add(paramCpf);

            var paramRg = new SqlParameter("rg", pessoa.Rg);
            insertCmd.Parameters.Add(paramRg);

            var paramIdade = new SqlParameter("idade", pessoa.Idade);
            insertCmd.Parameters.Add(paramIdade);

            var paramSexo = new SqlParameter("sexo", pessoa.sexo);
            insertCmd.Parameters.Add(paramSexo);

            insertCmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message);
            }
        }

        public void Atualizar(Pessoa pessoa)
        {
            try
            {
            
            var atualizarCmd = conexao.CreateCommand();
            atualizarCmd.CommandText = "Update Pessoa Set Nome = @nome, Cpf = @cpf, Rg = @rg, Idade = @idade, Sexo = @sexo Where Id = @id";

            var paramNome = new SqlParameter("nome", pessoa.Nome);
            atualizarCmd.Parameters.Add(paramNome);

            var paramCpf = new SqlParameter("cpf", pessoa.Cpf);
            atualizarCmd.Parameters.Add(paramCpf);

            var paramRg = new SqlParameter("rg", pessoa.Rg);
            atualizarCmd.Parameters.Add(paramRg);

            var paramIdade = new SqlParameter("idade", pessoa.Idade);
            atualizarCmd.Parameters.Add(paramIdade);

            var paramSexo = new SqlParameter("sexo", pessoa.sexo);
            atualizarCmd.Parameters.Add(paramSexo);

            var paramId = new SqlParameter("id", pessoa.Id);
            atualizarCmd.Parameters.Add(paramId);

            atualizarCmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message);
            }

        }

        public void Remover(Pessoa pessoa)
        {
            try
            {
                
            var removerCmd = conexao.CreateCommand();
            removerCmd.CommandText = "Delete From Pessoa Where Id = @id";

            var paramId = new SqlParameter("Id", pessoa.Id);
            removerCmd.Parameters.Remove(paramId);

            removerCmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message);
            }
        }

        public IList<Pessoa> Pessoas()
        {
            var lista = new List<Pessoa>();

            var listaCmd = conexao.CreateCommand();
            listaCmd.CommandText = "Select * From Pessoa";

            var result = listaCmd.ExecuteReader();

            while (result.Read())
            {
                var id = Convert.ToInt32(result["Id"]);
                var nome = Convert.ToString(result["Nome"]);
                var cpf = Convert.ToString(result["Cpf"]);
                var rg = Convert.ToString(result["Rg"]);
                var idade = Convert.ToInt32(result["Idade"]);
                var sexo = Convert.ToChar(result["Sexo"]);

                Pessoa pessoa = new Pessoa(id ,nome ,cpf ,rg ,idade ,sexo);
                lista.Add(pessoa);
            }
            result.Close();
            return lista;
        }
    }
}

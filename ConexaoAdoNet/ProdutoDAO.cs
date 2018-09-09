using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoAdoNet
{
    public class ProdutoDAO : IDisposable
    {
        private SqlConnection conexao;

        public ProdutoDAO()
        {
            this.conexao = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=LocalDB;Trusted_Connection=true;");
            this.conexao.Open();
        }

        public void Dispose()
        {
            conexao.Close();
        }

        public void Adicionar(Produto produto)
        {
            try { 
            var InsertCmd = conexao.CreateCommand();
            InsertCmd.CommandText = "Insert into Produtos (Nome, Categoria, Preco) Values (@nome, @categoria, @preco)";

            var paramNome = new SqlParameter("nome", produto.Nome);
            InsertCmd.Parameters.Add(paramNome);

            var paramCategoria = new SqlParameter("categoria", produto.Categoria);
            InsertCmd.Parameters.Add(paramCategoria);

            var paramPreco = new SqlParameter("preco", produto.Preco);
            InsertCmd.Parameters.Add(paramPreco);

            InsertCmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message);
            }
        }

        public void Atualizar(Produto produto, int id)
        {
            try { 
            var AtualizarCmd = conexao.CreateCommand();
            AtualizarCmd.CommandText = "Update Produtos set Nome = @nome, Categoria = @categoria, Preco = @preco Where Id = @id";

            var paramNome = new SqlParameter("nome", produto.Nome);
            AtualizarCmd.Parameters.Add(paramNome);

            var paramCategoria = new SqlParameter("categoria", produto.Categoria);
            AtualizarCmd.Parameters.Add(paramCategoria);

            var paramPreco = new SqlParameter("preco", produto.Preco);
            AtualizarCmd.Parameters.Add(paramPreco);

            var paramId = new SqlParameter("id", id);
            AtualizarCmd.Parameters.Add(paramId);

            AtualizarCmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message);
            }
        }

        public void Remover(Produto produto)
        {
            var RemoverCmd = conexao.CreateCommand();
            RemoverCmd.CommandText = "Delete From Produtos Where Id = @id";

            var paramId = new SqlParameter("id", produto.Id);
            RemoverCmd.Parameters.Add(paramId);

            RemoverCmd.ExecuteNonQuery();
        }

        public IList<Produto> Produtos()
        {
            var lista = new List<Produto>();

            var selectCmd = conexao.CreateCommand();
            selectCmd.CommandText = "Select * From Produtos";

            var result = selectCmd.ExecuteReader();

            while (result.Read())
            {
                Produto p = new Produto();
                p.Id = Convert.ToInt32(result["Id"]);
                p.Nome = Convert.ToString(result["Nome"]);
                p.Categoria = Convert.ToString(result["Categoria"]);
                p.Preco = Convert.ToDouble(result["Preco"]);
                lista.Add(p);
            }
            result.Close();
            return lista;
        }

    }
}

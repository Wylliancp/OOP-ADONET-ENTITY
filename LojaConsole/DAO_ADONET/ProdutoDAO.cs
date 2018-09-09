using System    ;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaConsole
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
            this.conexao.Close();
        }


        public void Adicionar(Produto produto)
        {
            try { 

            var insertCmd = conexao.CreateCommand();
            insertCmd.CommandText = "Insert Into Produto (Nome, Categoria, Preco) Values ( @nome, @categoria, @preco)";

            var paramNome = new SqlParameter("nome", produto.Nome);
            insertCmd.Parameters.Add(paramNome);

            var paramCategoria = new SqlParameter("categoria", produto.Categoria);
            insertCmd.Parameters.Add(paramCategoria);

            var paramPreco = new SqlParameter("preco", produto.Preco);
            insertCmd.Parameters.Add(paramPreco);

            insertCmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message);
            }
        }

        public void Atualizar(Produto produto)
        {
            try
            {

            
            var atualizarCmd = conexao.CreateCommand();
            atualizarCmd.CommandText = "Update Produto Set Nome = @nome, Categoria = @categoria, Preco = @preco Where Id = @id";

            var paramNome = new SqlParameter("nome", produto.Nome);
            var paramPreco = new SqlParameter("Preco", produto.Preco);
            var paramCategoria = new SqlParameter("categoria", produto.Categoria);
            var paramId = new SqlParameter("id", produto.Id);

            atualizarCmd.Parameters.Add(paramNome);
            atualizarCmd.Parameters.Add(paramCategoria);
            atualizarCmd.Parameters.Add(paramPreco);
            atualizarCmd.Parameters.Add(paramId);

            atualizarCmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message);
            }
        }

        public void Remover(Produto produto)
        {
            try { 
            var removerCmd = conexao.CreateCommand();
            removerCmd.CommandText = "Delete From Produtos Where Id = @id";

            var paramNome = new SqlParameter("Id", produto.Id);
            removerCmd.Parameters.Add(paramNome);

            removerCmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message);
            }
        }

        public IList<Produto> Produtos()
        {
            var lista = new List<Produto>();

            var selectCmd = conexao.CreateCommand();
            selectCmd.CommandText = "Select * From Produtos";

            var result = selectCmd.ExecuteReader();

            while (result.Read())
            {
                var id = Convert.ToInt32(result["Id"]);
                var nome = Convert.ToString(result["Nome"]);
                var categoria = Convert.ToString(result["Categoria"]);
                var preco = Convert.ToDouble(result["Preco"]);
                Produto produto = new Produto(id,nome,categoria,preco);
                lista.Add(produto);                
            }
            result.Close();
            return lista;
        }

    }
}

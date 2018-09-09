using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaConsole
{
    public class Conexao : IDisposable
    {

        private SqlConnection conexao;

        public SqlConnection conn()
        {
            this.conexao = new SqlConnection("server=(localdb)\\mssqllocaldb;database=localdb;trusted_connection=true;");
            // this.conexao.Open();
            // this.Dispose();
            return conexao;
        }

        public void Dispose()
        {
            this.conexao.Close();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Database
{
    public class BancoDeDados : IDisposable
    {
        private readonly SqlConnection conexao;
        public BancoDeDados()
        {
            conexao = new SqlConnection(@"data source=.\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=NEWDESENV");
            conexao.Open();
        }

        public void Comandos(string strQuery)
        {
            var comando = new SqlCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = conexao
            };
            comando.ExecuteNonQuery();
        }

        public SqlDataReader ComandosRetorno(string strQuery)
        {
            var comandoSelect = new SqlCommand(strQuery, conexao);
            return comandoSelect.ExecuteReader();
        }

        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }

        }
    }
}

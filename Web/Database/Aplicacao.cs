using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Database
{
    public class Aplicacao
    {
        private void InsertClientes(Clientes cliente)
        {
            var bd = new BancoDeDados();
            var strQuery = "";
            strQuery += "INSERT INTO CLIENTES";
            strQuery += string.Format(" VALUES ('{0}')", cliente.Nome);
            using (bd)
            {
                bd.Comandos(strQuery);
            }
        }

        private void UpdateClientes(Clientes cliente)
        {
            var bd = new BancoDeDados();
            var strQuery = "";
            strQuery += "UPDATE CLIENTES SET ";
            strQuery += string.Format("Nome = '{0}'", cliente.Nome);
            strQuery += string.Format("WHERE CODCLI = {0}", cliente.Id);
            using (bd)
            {
                bd.Comandos(strQuery);
            }
        }

        public void InsertOrUpdate(Clientes cliente)
        {
            if (cliente.Id > 0)
            {
                UpdateClientes(cliente);
            }
            else
            {
                InsertClientes(cliente);
            }
        }

        public void DeleteClientes(int id)
        {
            var bd = new BancoDeDados();
            var strQuery = string.Format("DELETE FROM CLIENTES WHERE CODCLI = {0}", id);

            using (bd)
            {
                bd.Comandos(strQuery);
            }
        }

        public List<Clientes> SelectClientes()
        {
            var bd = new BancoDeDados();
            using (bd)
            {
                var strQuery = "SELECT * FROM CLIENTES";
                var retorno = bd.ComandosRetorno(strQuery);
                return ClienteList(retorno);
            }
        }

        public Clientes SelectIdClientes(int id)
        {
            var bd = new BancoDeDados();
            using (bd)
            {
                var strQuery = string.Format("SELECT * FROM CLIENTES WHERE CODCLI = {0}", id);
                var retorno = bd.ComandosRetorno(strQuery);
                return ClienteList(retorno).FirstOrDefault();
            }
        }

        private List<Clientes> ClienteList(SqlDataReader reader)
        {
            var clientes = new List<Clientes>();
            while (reader.Read())
            {
                var tmp = new Clientes()
                {
                    Id = int.Parse(reader["CODCLI"].ToString()),
                    Nome = reader["NOME"].ToString()
                };

                clientes.Add(tmp);
            }
            reader.Close();
            return clientes;
        }
    }
}

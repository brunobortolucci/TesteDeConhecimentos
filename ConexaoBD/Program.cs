using System;
using System.Data.SqlClient;

namespace ConexaoBD
{
    class Program
    {
        static void Main(string[] args)
        {

            var bd = new BancoDeDados();
            var aplicacao = new Aplicacao();

            SqlConnection conexao = new SqlConnection(@"data source=.\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=NEWDESENV");
            conexao.Open();

            //DELETAR
            aplicacao.DeleteClientes(3);

            //INSERIR
            Console.Write("Digite o Nome: ");
            string nome = Console.ReadLine();
            var cliente = new Clientes
            {
                 Nome = nome
            };
            aplicacao.InsertOrUpdate(cliente);

            //EDITAR
            cliente.Id = 1;
            cliente.Nome = "JOSE ANTONIO";
            aplicacao.InsertOrUpdate(cliente);

            //BUSCAR
            var dados = aplicacao.SelectClientes();
            foreach (var clientes in dados)
            {
                Console.WriteLine("id: {0}, nome: {1}", clientes.Id, clientes.Nome);
            }
        }
    }
}

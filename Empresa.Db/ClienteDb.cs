using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empresa.Models;
using System.Data.SqlClient;

namespace Empresa.Db
{
    class ClienteDb
    {
        public void Incluir(Cliente cliente)
        {
            string comandoSql = @"INSERT INTO Cliente(Id, Nome, Email, Telefone) VALUES(@Id, @Nome, @Email, @Telefone)";

            var con = new SqlConnection(Db.Conexao);
            var cmd = new SqlCommand(comandoSql, con);

            cmd.Parameters.AddWithValue("@Id", cliente.Id);
            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@Email", cliente.Email);
            cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void Alterar(Cliente cliente)
        {
            string comandoSql = @"UPDATE Cliente SET Nome = @Nome, Email = @Email, Telefone = @Telefone WHERE Id = @Id";

            var con = new SqlConnection(Db.Conexao);
            var cmd = new SqlCommand(comandoSql, con);

            cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@Email", cliente.Email);
            cmd.Parameters.AddWithValue("@Telefone", cliente.Telefone);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void Excluir(int id)
        {
            string comandoSql = "DELETE Cliente WHERE Id = @Id";

            var con = new SqlConnection(Db.Conexao);
            var cmd = new SqlCommand(comandoSql, con);

            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }



    }
}

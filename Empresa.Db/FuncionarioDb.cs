using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Empresa.Models;

namespace Empresa.Db
{
    public class FuncionarioDb
    {
        public void Incluir(Funcionario funcionario)
        {
            string comandoSql = @"INSERT INTO Funcionario (Nome, Email, Telefone, Cpf, Cargo, Salario, Admissao) VALUES (@Nome, @Email, @Telefone, @Cpf, @Cargo, @Salario, @Admissao)";

            var con = new SqlConnection(Db.Conexao);
            var cmd = new SqlCommand(comandoSql, con);

            cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
            cmd.Parameters.AddWithValue("@Email", funcionario.Email);
            cmd.Parameters.AddWithValue("@Telefone", funcionario.Telefone);
            cmd.Parameters.AddWithValue("@Cpf", funcionario.Cpf);
            cmd.Parameters.AddWithValue("@Cargo", funcionario.Cargo);
            cmd.Parameters.AddWithValue("@Salario", funcionario.Salario);
            cmd.Parameters.AddWithValue("@Admissao", funcionario.DataAdmissao.ToString("dd/MM/yyyy"));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


        }
    }
}

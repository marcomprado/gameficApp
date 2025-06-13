using GamificacaoApp.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace GamificacaoApp.Services
{
    public class FuncionarioService
    {
        private Database db = new Database();

        public void Cadastrar(Funcionario funcionario)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Funcionario (nome, data_admissao, data_nascimento, setor) VALUES (@nome, @data_admissao, @data_nascimento, @setor)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@data_admissao", funcionario.DataAdmissao);
                cmd.Parameters.AddWithValue("@data_nascimento", funcionario.DataNascimento);
                cmd.Parameters.AddWithValue("@setor", funcionario.Setor);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Funcionario> ListarTodos()
        {
            var lista = new List<Funcionario>();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Funcionario";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Funcionario
                        {
                            Id = reader.GetInt32("id"),
                            Nome = reader.GetString("nome"),
                            DataAdmissao = reader.GetDateTime("data_admissao"),
                            DataNascimento = reader.GetDateTime("data_nascimento"),
                            Setor = reader.GetString("setor")
                        });
                    }
                }
            }
            return lista;
        }
    }
}

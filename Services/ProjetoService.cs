using GamificacaoApp.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace GamificacaoApp.Services
{
    public class ProjetoService
    {
        private Database db = new Database();

        public void Cadastrar(Projeto projeto)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Projeto (nome, data_inicio, cliente) VALUES (@nome, @data_inicio, @cliente)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nome", projeto.Nome);
                cmd.Parameters.AddWithValue("@data_inicio", projeto.DataInicio);
                cmd.Parameters.AddWithValue("@cliente", projeto.Cliente);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Projeto> ListarTodos()
        {
            var lista = new List<Projeto>();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Projeto";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Projeto
                        {
                            Id = reader.GetInt32("id"),
                            Nome = reader.GetString("nome"),
                            DataInicio = reader.GetDateTime("data_inicio"),
                            Cliente = reader.GetString("cliente")
                        });
                    }
                }
            }
            return lista;
        }
    }
}

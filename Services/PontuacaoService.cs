using GamificacaoApp.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace GamificacaoApp.Services
{
    public class PontuacaoService
    {
        private Database db = new Database();

        public void Cadastrar(Pontuacao pontuacao)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Pontuacao (projeto_id, fase, pontos) VALUES (@projeto_id, @fase, @pontos)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@projeto_id", pontuacao.ProjetoId);
                cmd.Parameters.AddWithValue("@fase", pontuacao.Fase);
                cmd.Parameters.AddWithValue("@pontos", pontuacao.Pontos);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Pontuacao> ListarPorProjeto(int projetoId)
        {
            var lista = new List<Pontuacao>();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Pontuacao WHERE projeto_id = @projeto_id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@projeto_id", projetoId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Pontuacao
                        {
                            Id = reader.GetInt32("id"),
                            ProjetoId = reader.GetInt32("projeto_id"),
                            Fase = reader.GetString("fase"),
                            Pontos = reader.GetInt32("pontos")
                        });
                    }
                }
            }
            return lista;
        }
    }
}

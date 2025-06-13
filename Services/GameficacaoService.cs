using GamificacaoApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GamificacaoApp.Services
{
    public class GameficacaoService
    {
        private Database db = new Database();

        public void Registrar(Gameficacao gameficacao)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Gameficacao (funcionario_id, projeto_id, fase, data, pontos) 
                                 VALUES (@funcionario_id, @projeto_id, @fase, @data, @pontos)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@funcionario_id", gameficacao.FuncionarioId);
                cmd.Parameters.AddWithValue("@projeto_id", gameficacao.ProjetoId);
                cmd.Parameters.AddWithValue("@fase", gameficacao.Fase);
                cmd.Parameters.AddWithValue("@data", gameficacao.Data);
                cmd.Parameters.AddWithValue("@pontos", gameficacao.Pontos);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Gameficacao> ListarPorFuncionario(int funcionarioId)
        {
            var lista = new List<Gameficacao>();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Gameficacao WHERE funcionario_id = @funcionario_id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@funcionario_id", funcionarioId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Gameficacao
                        {
                            Id = reader.GetInt32("id"),
                            FuncionarioId = reader.GetInt32("funcionario_id"),
                            ProjetoId = reader.GetInt32("projeto_id"),
                            Fase = reader.GetString("fase"),
                            Data = reader.GetDateTime("data"),
                            Pontos = reader.GetInt32("pontos")
                        });
                    }
                }
            }
            return lista;
        }

        public List<Gameficacao> ListarTodos()
        {
            var lista = new List<Gameficacao>();
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Gameficacao";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Gameficacao
                        {
                            Id = reader.GetInt32("id"),
                            FuncionarioId = reader.GetInt32("funcionario_id"),
                            ProjetoId = reader.GetInt32("projeto_id"),
                            Fase = reader.GetString("fase"),
                            Data = reader.GetDateTime("data"),
                            Pontos = reader.GetInt32("pontos")
                        });
                    }
                }
            }
            return lista;
        }

    }
}

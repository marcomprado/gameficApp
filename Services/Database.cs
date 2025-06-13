using MySql.Data.MySqlClient;

namespace GamificacaoApp.Services
{
    public class Database
    {
        // Declaração string de conexão
        private string connectionString = "server=localhost;database=Gamificacao;user=root;password=1529350#OaZ#";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}

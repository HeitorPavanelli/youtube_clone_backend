using System.Text;
using Dapper;
using Microsoft.Data.SqlClient;
using youtubeClone.Models;

namespace youtubeClone.Repositories
{
    public class UsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public IEnumerable<Usuario> GetUsuarioLogin(string email, string senha)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = new StringBuilder();
            sql.Append("SELECT * FROM Usuario ");
            sql.Append("WHERE email = @Email AND senha = @Senha");

            return connection.Query<Usuario>(sql.ToString(), new { Email = email, Senha = senha });
        }

        public void AddUser(Usuario usuario)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = new StringBuilder();
            sql.Append("INSERT INTO Usuario (nome, email, senha) ");
            sql.Append("VALUES (@Nome, @Email, @Senha);");

            connection.Execute(sql.ToString(), usuario);
        }

        public IEnumerable<Estatistica>  consultaVideosPostados(int usuarioId)
        { 
            using var connection = new SqlConnection(_connectionString);
            var sql = new StringBuilder();
            sql.Append("SELECT ");
            sql.Append("SUM(CASE WHEN usuario_id = @Usuario THEN 1 ELSE 0 END) AS videos_usuario_logado, ");
            sql.Append("SUM(CASE WHEN usuario_id <> @Usuario THEN 1 ELSE 0 END) AS videos_outros_usuarios ");
            sql.Append("FROM Videos");

            return connection.Query<Estatistica>(sql.ToString(), new { Usuario = usuarioId });
        }
    }
}
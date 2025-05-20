using System.Text;
using Dapper;
using Microsoft.Data.SqlClient;
using youtubeClone.Models;

namespace youtubeClone.Repositories
{
    public class VideosRepository
    {
        private readonly string _connectionString;

        public VideosRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public IEnumerable<Videos> buscaVideos()
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = new StringBuilder();

            sql.Append("SELECT v.*, u.* ");
            sql.Append("FROM Videos v ");
            sql.Append("INNER JOIN Usuario u ON v.usuario_id = u.id");

            var videos = connection.Query<Videos, Usuario, Videos>(
                sql.ToString(),
                (video, usuario) =>
                {
                    video.usuario = usuario;
                    return video;
                },
                splitOn: "id"
            );

            return videos;
        }

        public void addVideo(Videos video)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = new StringBuilder();
            sql.Append("INSERT INTO Videos (titulo, descricao, link, usuario_id, visualizacoes, dataPostada) ");
            sql.Append("VALUES (@titulo, @descricao, @link, @usuario_id, @visualizacoes, @dataPostada);");

            connection.Execute(sql.ToString(), video);
        }

        public void atualizaVisualizacoes(AtualizaVisualizacaoIN video)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = new StringBuilder();
            sql.Append("UPDATE Videos ");
            sql.Append("SET visualizacoes = @visualizacoes ");
            sql.Append("WHERE usuario_id = @usuario_id AND link = @link;");

            connection.Execute(sql.ToString(), new
            {
                visualizacoes = video.NovasVisualizacoes,
                usuario_id = video.VideoId,
                link = video.Link
            });
        }
    }
}
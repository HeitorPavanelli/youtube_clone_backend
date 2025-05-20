namespace youtubeClone.Models
{
    public class Videos
    {
        public int Id { get; set; }
        public string? titulo { get; set; }
        public string? descricao { get; set; }
        public string? link { get; set; }
        public int? usuario_id { get; set; }
        public int? visualizacoes { get; set; } = 0;
        public DateTime? dataPostada { get; set; } = DateTime.Now;
        public Usuario? usuario { get; set; }
    }
}
using youtubeClone.Repositories;
using youtubeClone.Models;

namespace youtubeClone.Services
{
    public class VideosService
    {
        private readonly VideosRepository _repository;

        public VideosService(VideosRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Videos> buscaVideos()
        {
            return _repository.buscaVideos();
        }

        public void adicionarVideo(Videos video)
        {
            _repository.addVideo(video);
        }

        public void atualizaVisualizacoes(AtualizaVisualizacaoIN video)
        {
            _repository.atualizaVisualizacoes(video);
        }
    }
}

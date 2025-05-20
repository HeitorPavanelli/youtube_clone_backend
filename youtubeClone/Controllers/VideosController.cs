using Microsoft.AspNetCore.Mvc;
using youtubeClone.Models;
using youtubeClone.Services;

namespace youtubeClone.Controllers
{
    [ApiController]
    [Route("youtube/videos")]
    public class VideosController : ControllerBase
    {
        private readonly VideosService _service;

        public VideosController(VideosService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult buscaVideos()
        {
            var videos = _service.buscaVideos();

            return Ok(videos);
        }

        [HttpPost]
        public IActionResult insereVideos([FromBody] Videos video)
        {
            _service.adicionarVideo(video);
            return CreatedAtAction(nameof(buscaVideos), new { id = video.Id }, video);
        }

        [HttpPost("atualiza-visualizacoes")]
        public IActionResult AtualizaVisualizacoes([FromBody] AtualizaVisualizacaoIN video)
        {
            _service.atualizaVisualizacoes(video);
            return Ok(new { mensagem = "Visualizações atualizadas com sucesso." });
        }

    }
}
using Microsoft.AspNetCore.Mvc;
using youtubeClone.Models;
using youtubeClone.Services;

namespace youtubeClone.Controllers
{
    [ApiController]
    [Route("youtube/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult buscaUsuario([FromQuery] string email, [FromQuery] string senha)
        {
            var usuarios = _service.BuscarUsuario(email, senha);
            if (usuarios == null)
            {
                return NotFound("Usuario nao encontrado");
            }

            return Ok(usuarios);
        }

        [HttpGet("estatistica")]
        public IActionResult consultaVideosPostados([FromQuery] int usuarioId)
        {
            var videos = _service.consultaVideosPostados(usuarioId);

            return Ok(videos);
        }


        [HttpPost]
        public IActionResult insereUsuario([FromBody] Usuario usuario)
        {
            _service.CriarUsuario(usuario);
            return CreatedAtAction(nameof(buscaUsuario), new { id = usuario.Id }, usuario);
        }
        
    }
}
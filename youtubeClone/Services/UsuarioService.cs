using youtubeClone.Repositories;
using youtubeClone.Models;

namespace youtubeClone.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _repository;

        public UsuarioService(UsuarioRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Usuario> BuscarUsuario(string email, string senha)
        {
            return _repository.GetUsuarioLogin(email, senha);
        }

        public IEnumerable<Estatistica> consultaVideosPostados(int usuarioId)
        {
            return _repository.consultaVideosPostados(usuarioId);
        }

        public void CriarUsuario(Usuario usuario)
        {
            _repository.AddUser(usuario);
        }
    }
}

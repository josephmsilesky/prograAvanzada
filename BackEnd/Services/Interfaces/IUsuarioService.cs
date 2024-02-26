using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface IUsuarioService
    {
        IEnumerable<UsuarioModel> GetUsuarios();
        UsuarioModel GetById(int id);
        bool AddUsuario(UsuarioModel usuario);
        bool UpdateUsuario(UsuarioModel usuario);
        bool DeteleUsuario(UsuarioModel usuario);
    }
}

using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public UsuarioService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }



        public bool AddUsuario(UsuarioModel usuario)
        {
            Usuario entity = Convertir(usuario);
            _unidadDeTrabajo._usuarioDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        UsuarioModel Convertir(Usuario usuario)
        {
            return new UsuarioModel
            {

                IdUsuario = (int)usuario.IdUsuario,
                CorreoElectronico = usuario.CorreoElectronico,
                Contrasenna = usuario.Contrasenna,
                Identificacion = usuario.Identificacion,
                Nombre = usuario.Nombre,
                Estado = usuario.Estado,
                IdRol = usuario.IdRol,
                UsaClaveTemporal = usuario.UsaClaveTemporal,
                FechaCaducidad = usuario.FechaCaducidad

            };
        }

        Usuario Convertir(UsuarioModel usuario)
        {
            return new Usuario
            {
                IdUsuario = (int)usuario.IdUsuario,
                CorreoElectronico = usuario.CorreoElectronico,
                Contrasenna = usuario.Contrasenna,
                Identificacion = usuario.Identificacion,
                Nombre = usuario.Nombre,
                Estado = usuario.Estado,
                IdRol = usuario.IdRol,
                UsaClaveTemporal = usuario.UsaClaveTemporal,
                FechaCaducidad = usuario.FechaCaducidad
            };
        }
        public bool DeteleUsuario(UsuarioModel usuario)
        {
            Usuario entity = Convertir(usuario);
            _unidadDeTrabajo._usuarioDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public UsuarioModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._usuarioDAL.Get(id);

            UsuarioModel UsuarioModel = Convertir(entity);
            return UsuarioModel;
        }

        public IEnumerable<UsuarioModel> GetUsuarios()
        {

            var result = _unidadDeTrabajo._usuarioDAL.GetAll();
            List<UsuarioModel> lista = new List<UsuarioModel>();
            foreach (var Usuario in result)
            {
                lista.Add(Convertir(Usuario));


            }
            return lista;
        }
        public bool UpdateUsuario(UsuarioModel usuario)
        {
            Usuario entity = Convertir(usuario);
            _unidadDeTrabajo._usuarioDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }
    }
}

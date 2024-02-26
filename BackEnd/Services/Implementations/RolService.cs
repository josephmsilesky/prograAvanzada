using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class RolService : IRolService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public RolService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }



        public bool AddRol(RolModel rol)
        {
            Rol entity = Convertir(rol);
            _unidadDeTrabajo._rolDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        RolModel Convertir(Rol rol)
        {
            return new RolModel
            {

                IdRol = (int)rol.IdRol,
                NombreRol = rol.NombreRol


            };
        }

        Rol Convertir(RolModel rol)
        {
            return new Rol
            {
                IdRol = (int)rol.IdRol,
                NombreRol = rol.NombreRol

            };
        }
        public bool DeteleRol(RolModel rol)
        {
            Rol entity = Convertir(rol);
            _unidadDeTrabajo._rolDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public RolModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._rolDAL.Get(id);

            RolModel RolModel = Convertir(entity);
            return RolModel;
        }

        public IEnumerable<RolModel> GetRols()
        {

            var result = _unidadDeTrabajo._rolDAL.GetAll();
            List<RolModel> lista = new List<RolModel>();
            foreach (var Rol in result)
            {
                lista.Add(Convertir(Rol));


            }
            return lista;
        }
        public bool UpdateRol(RolModel rol)
        {
            Rol entity = Convertir(rol);
            _unidadDeTrabajo._rolDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }
    }
}

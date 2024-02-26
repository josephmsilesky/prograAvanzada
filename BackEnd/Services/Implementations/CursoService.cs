using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class CursoService : ICursoService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public CursoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }



        public bool AddCurso(CursoModel curso)
        {
            Curso entity = Convertir(curso);
            _unidadDeTrabajo._cursoDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        CursoModel Convertir(Curso curso)
        {
            return new CursoModel
            {

                IdCurso = (int)curso.IdCurso,
                Nombre = curso.Nombre,
                Descripcion = curso.Descripcion,
                Precio = curso.Precio,
                Stock = curso.Stock,
                Imagen = curso.Imagen,
                IdCategoria = curso.IdCategoria

            };
        }

        Curso Convertir(CursoModel curso)
        {
            return new Curso
            {
                IdCurso = (int)curso.IdCurso,
                Nombre = curso.Nombre,
                Descripcion = curso.Descripcion,
                Precio = curso.Precio,
                Stock = curso.Stock,
                Imagen = curso.Imagen,
                IdCategoria = curso.IdCategoria
            };
        }
        public bool DeteleCurso(CursoModel curso)
        {
            Curso entity = Convertir(curso);
            _unidadDeTrabajo._cursoDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public CursoModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._cursoDAL.Get(id);

            CursoModel CursoModel = Convertir(entity);
            return CursoModel;
        }

        public IEnumerable<CursoModel> GetCursos()
        {

            var result = _unidadDeTrabajo._cursoDAL.GetAll();
            List<CursoModel> lista = new List<CursoModel>();
            foreach (var Curso in result)
            {
                lista.Add(Convertir(Curso));


            }
            return lista;
        }
        public bool UpdateCurso(CursoModel curso)
        {
            Curso entity = Convertir(curso);
            _unidadDeTrabajo._cursoDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }
    }
}

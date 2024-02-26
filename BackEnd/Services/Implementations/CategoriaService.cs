using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class CategoriaService : ICategoriaService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public CategoriaService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }



        public bool AddCategoria(CategoriaModel categoria)
        {
            Categorium entity = Convertir(categoria);
            _unidadDeTrabajo._categoriaDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        CategoriaModel Convertir(Categorium categoria)
        {
            return new CategoriaModel
            {

                IdCategoria = (int)categoria.IdCategoria,
                NombreCategoria = categoria.NombreCategoria


            };
        }

        Categorium Convertir(CategoriaModel categoria)
        {
            return new Categorium
            {
                IdCategoria = (int)categoria.IdCategoria,
                NombreCategoria = categoria.NombreCategoria
            };
        }
        public bool DeteleCategoria(CategoriaModel categoria)
        {
            Categorium entity = Convertir(categoria);
            _unidadDeTrabajo._categoriaDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public CategoriaModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._categoriaDAL.Get(id);

            CategoriaModel CategoriaModel = Convertir(entity);
            return CategoriaModel;
        }

        public IEnumerable<CategoriaModel> GetCategorias()
        {

            var result = _unidadDeTrabajo._categoriaDAL.GetAll();
            List<CategoriaModel> lista = new List<CategoriaModel>();
            foreach (var Categoria in result)
            {
                lista.Add(Convertir(Categoria));


            }
            return lista;
        }
        public bool UpdateCategoria(CategoriaModel categoria)
        {
            Categorium entity = Convertir(categoria);
            _unidadDeTrabajo._categoriaDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }
    }
}

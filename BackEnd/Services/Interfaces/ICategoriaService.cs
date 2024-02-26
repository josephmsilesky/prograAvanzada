using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface ICategoriaService
    {
        IEnumerable<CategoriaModel> GetCategorias();
        CategoriaModel GetById(int id);
        bool AddCategoria(CategoriaModel categoria);
        bool UpdateCategoria(CategoriaModel categoria);
        bool DeteleCategoria(CategoriaModel categoria);
    }
}

using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface ICursoService
    {
        IEnumerable<CursoModel> GetCursos();
        CursoModel GetById(int id);
        bool AddCurso(CursoModel curso);
        bool UpdateCurso(CursoModel curso);
        bool DeteleCurso(CursoModel curso);
    }
}

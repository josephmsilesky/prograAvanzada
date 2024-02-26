using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface IRolService
    {
        IEnumerable<RolModel> GetRols();
        RolModel GetById(int id);
        bool AddRol(RolModel rol);
        bool UpdateRol(RolModel rol);
        bool DeteleRol(RolModel rol);
    }
}

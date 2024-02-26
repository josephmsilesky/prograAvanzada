using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface IBitacoraService
    {
        IEnumerable<BitacoraModel> GetBitacoras();
        BitacoraModel GetById(int id);
        bool AddBitacora(BitacoraModel bitacora);
        bool UpdateBitacora(BitacoraModel bitacora);
        bool DeteleBitacora(BitacoraModel bitacora);
    }
}

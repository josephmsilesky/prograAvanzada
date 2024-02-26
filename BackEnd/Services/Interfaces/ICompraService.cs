using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface ICompraService
    {
        IEnumerable<CompraModel> GetCompras();
        CompraModel GetById(int id);
        bool AddCompra(CompraModel compra);
        bool UpdateCompra(CompraModel compra);
        bool DeteleCompra(CompraModel compra);
    }
}

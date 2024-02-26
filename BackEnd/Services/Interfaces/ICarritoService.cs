using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface ICarritoService
    {
        IEnumerable<CarritoModel> GetCarritos();
        CarritoModel GetById(int id);
        bool AddCarrito(CarritoModel carrito);
        bool UpdateCarrito(CarritoModel carrito);
        bool DeteleCarrito(CarritoModel carrito);
    }
}

using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class CarritoService : ICarritoService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public CarritoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }



        public bool AddCarrito(CarritoModel carrito)
        {
            Carrito entity = Convertir(carrito);
            _unidadDeTrabajo._carritoDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        CarritoModel Convertir(Carrito carrito)
        {
            return new CarritoModel
            {

                IdCarrito = (int)carrito.IdCarrito,
                FechaRegistro = carrito.FechaRegistro,
                IdCurso = (int)carrito.IdCurso,
                IdUsuario = (int)carrito.IdUsuario


            };
        }

        Carrito Convertir(CarritoModel carrito)
        {
            return new Carrito
            {
                IdCarrito = (int)carrito.IdCarrito,
                FechaRegistro = carrito.FechaRegistro,
                IdCurso = (int)carrito.IdCurso,
                IdUsuario = (int)carrito.IdUsuario

            };
        }
        public bool DeteleCarrito(CarritoModel carrito)
        {
            Carrito entity = Convertir(carrito);
            _unidadDeTrabajo._carritoDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public CarritoModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._carritoDAL.Get(id);

            CarritoModel CarritoModel = Convertir(entity);
            return CarritoModel;
        }

        public IEnumerable<CarritoModel> GetCarritos()
        {

            var result = _unidadDeTrabajo._carritoDAL.GetAll();
            List<CarritoModel> lista = new List<CarritoModel>();
            foreach (var Carrito in result)
            {
                lista.Add(Convertir(Carrito));


            }
            return lista;
        }
        public bool UpdateCarrito(CarritoModel carrito)
        {
            Carrito entity = Convertir(carrito);
            _unidadDeTrabajo._carritoDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }
    }
}

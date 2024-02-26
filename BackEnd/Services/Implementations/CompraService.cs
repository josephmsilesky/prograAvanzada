using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class CompraService : ICompraService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public CompraService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }



        public bool AddCompra(CompraModel compra)
        {
            Compra entity = Convertir(compra);
            _unidadDeTrabajo._compraDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        CompraModel Convertir(Compra compra)
        {
            return new CompraModel
            {

                IdCompra = (int)compra.IdCompra,
                IdUsuario = (int)compra.IdUsuario,
                IdCurso = (int)compra.IdCurso,
                FechaCompra = compra.FechaCompra,
                PrecioPagado = compra.PrecioPagado


            };
        }

        Compra Convertir(CompraModel compra)
        {
            return new Compra
            {
                IdCompra = (int)compra.IdCompra,
                IdUsuario = (int)compra.IdUsuario,
                IdCurso = (int)compra.IdCurso,
                FechaCompra = compra.FechaCompra,
                PrecioPagado = compra.PrecioPagado
            };
        }
        public bool DeteleCompra(CompraModel compra)
        {
            Compra entity = Convertir(compra);
            _unidadDeTrabajo._compraDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public CompraModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._compraDAL.Get(id);

            CompraModel CompraModel = Convertir(entity);
            return CompraModel;
        }

        public IEnumerable<CompraModel> GetCompras()
        {

            var result = _unidadDeTrabajo._compraDAL.GetAll();
            List<CompraModel> lista = new List<CompraModel>();
            foreach (var Compra in result)
            {
                lista.Add(Convertir(Compra));


            }
            return lista;
        }
        public bool UpdateCompra(CompraModel compra)
        {
            Compra entity = Convertir(compra);
            _unidadDeTrabajo._compraDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }
    }
}

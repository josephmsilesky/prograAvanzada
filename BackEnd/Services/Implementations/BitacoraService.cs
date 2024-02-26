using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class BitacoraService : IBitacoraService
    {
        public IUnidadDeTrabajo _unidadDeTrabajo;

        public BitacoraService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }



        public bool AddBitacora(BitacoraModel bitacora)
        {
            Bitacora entity = Convertir(bitacora);
            _unidadDeTrabajo._bitacoraDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        BitacoraModel Convertir(Bitacora bitacora)
        {
            return new BitacoraModel
            {

                IdBitacora = (int)bitacora.IdBitacora,
                FechaHora = bitacora.FechaHora,
                Origen = bitacora.Origen,
                Mensaje = bitacora.Mensaje,
                IdUsuario = (int)bitacora.IdUsuario,
                DireccionIp = bitacora.DireccionIp


            };
        }

        Bitacora Convertir(BitacoraModel bitacora)
        {
            return new Bitacora
            {
                IdBitacora = (int)bitacora.IdBitacora,
                FechaHora = bitacora.FechaHora,
                Origen = bitacora.Origen,
                Mensaje = bitacora.Mensaje,
                IdUsuario = (int)bitacora.IdUsuario,
                DireccionIp = bitacora.DireccionIp
            };
        }
        public bool DeteleBitacora(BitacoraModel bitacora)
        {
            Bitacora entity = Convertir(bitacora);
            _unidadDeTrabajo._bitacoraDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public BitacoraModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._bitacoraDAL.Get(id);

            BitacoraModel BitacoraModel = Convertir(entity);
            return BitacoraModel;
        }

        public IEnumerable<BitacoraModel> GetBitacoras()
        {

            var result = _unidadDeTrabajo._bitacoraDAL.GetAll();
            List<BitacoraModel> lista = new List<BitacoraModel>();
            foreach (var Bitacora in result)
            {
                lista.Add(Convertir(Bitacora));


            }
            return lista;
        }
        public bool UpdateBitacora(BitacoraModel bitacora)
        {
            Bitacora entity = Convertir(bitacora);
            _unidadDeTrabajo._bitacoraDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }
    }
}

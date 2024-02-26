using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class CarritoDALImpl : DALGenericoImpl<Carrito>, ICarritoDAL
    {
        ProyectoAvanzadaContext _context;

        public CarritoDALImpl(ProyectoAvanzadaContext context) : base(context)
        {
            _context = context;
        }
    }
}
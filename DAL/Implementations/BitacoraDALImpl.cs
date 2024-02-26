using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class BitacoraDALImpl : DALGenericoImpl<Bitacora>, IBitacoraDAL
    {
        ProyectoAvanzadaContext _context;

        public BitacoraDALImpl(ProyectoAvanzadaContext context) : base(context)
        {
            _context = context;
        }
    }
}

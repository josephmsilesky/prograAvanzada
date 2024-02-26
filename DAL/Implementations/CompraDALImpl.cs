using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class CompraDALImpl : DALGenericoImpl<Compra>, ICompraDAL
    {
        ProyectoAvanzadaContext _context;

        public CompraDALImpl(ProyectoAvanzadaContext context) : base(context)
        {
            _context = context;
        }
    }
}
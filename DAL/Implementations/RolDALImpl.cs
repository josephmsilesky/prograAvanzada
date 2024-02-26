using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class RolDALImpl : DALGenericoImpl<Rol>, IRolDAL
    {
        ProyectoAvanzadaContext _context;

        public RolDALImpl(ProyectoAvanzadaContext context) : base(context)
        {
            _context = context;
        }
    }
}
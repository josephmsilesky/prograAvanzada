using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class UsuarioDALImpl : DALGenericoImpl<Usuario>, IUsuarioDAL
    {
        ProyectoAvanzadaContext _context;

        public UsuarioDALImpl(ProyectoAvanzadaContext context) : base(context)
        {
            _context = context;
        }
    }
}

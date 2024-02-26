using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class CategoriaDALImpl : DALGenericoImpl<Categorium>, ICategoriaDAL
    {
        ProyectoAvanzadaContext _context;

        public CategoriaDALImpl(ProyectoAvanzadaContext context) : base(context)
        {
            _context = context;
        }
    }
}
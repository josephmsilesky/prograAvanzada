using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class CursoDALImpl : DALGenericoImpl<Curso>, ICursoDAL
    {
        ProyectoAvanzadaContext _context;

        public CursoDALImpl(ProyectoAvanzadaContext context) : base(context)
        {
            _context = context;
        }
    }
}

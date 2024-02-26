using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo : IDisposable
    {

        IBitacoraDAL _bitacoraDAL { get; }
        ICarritoDAL _carritoDAL { get; }
        ICategoriaDAL _categoriaDAL { get; }

        ICompraDAL _compraDAL { get; }

        ICursoDAL _cursoDAL { get; }
        IRolDAL _rolDAL { get; }
        IUsuarioDAL _usuarioDAL { get; }

        bool Complete();
    }
}
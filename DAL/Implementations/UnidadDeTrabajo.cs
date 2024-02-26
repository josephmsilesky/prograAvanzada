using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {

        public IBitacoraDAL _bitacoraDAL { get; }
        public ICarritoDAL _carritoDAL { get; }
        public ICategoriaDAL _categoriaDAL { get; }

        public ICursoDAL _cursoDAL { get; }

        public ICompraDAL _compraDAL { get; }
        public IRolDAL _rolDAL { get; }
        public IUsuarioDAL _usuarioDAL { get; }




        private readonly ProyectoAvanzadaContext _context;

        public UnidadDeTrabajo(ProyectoAvanzadaContext proyectoContext, IBitacoraDAL bitacoraDAL, ICarritoDAL carritoDAL, ICategoriaDAL categoriaDAL, ICursoDAL cursoDAL, ICompraDAL compraDAL, IRolDAL rolDAL, IUsuarioDAL usuarioDAL)
        {
            _context = proyectoContext;


            _bitacoraDAL = bitacoraDAL;

            _carritoDAL = carritoDAL;

            _categoriaDAL = categoriaDAL;

            _cursoDAL = cursoDAL;

            _compraDAL = compraDAL;

            _rolDAL = rolDAL;

            _usuarioDAL = usuarioDAL;


        }







        public bool Complete()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
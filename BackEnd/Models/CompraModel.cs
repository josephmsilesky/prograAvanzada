namespace BackEnd.Models
{
    public class CompraModel
    {
        public int IdCompra { get; set; }
        public int IdUsuario { get; set; }
        public int IdCurso { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal PrecioPagado { get; set; }

    }
}

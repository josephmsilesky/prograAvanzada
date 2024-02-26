namespace BackEnd.Models
{
    public class BitacoraModel
    {
        public int IdBitacora { get; set; }
        public DateTime FechaHora { get; set; }
        public string Origen { get; set; }
        public string Mensaje { get; set; }
        public int IdUsuario { get; set; }
        public string DireccionIp { get; set; }


    }
}

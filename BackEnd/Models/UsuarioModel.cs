namespace BackEnd.Models
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasenna { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public int IdRol { get; set; }
        public bool UsaClaveTemporal { get; set; }
        public DateTime FechaCaducidad { get; set; }



    }
}

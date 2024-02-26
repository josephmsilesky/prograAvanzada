using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Usuario
{
    public long IdUsuario { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public string Contrasenna { get; set; } = null!;

    public string Identificacion { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public bool Estado { get; set; }

    public int IdRol { get; set; }

    public bool UsaClaveTemporal { get; set; }

    public DateTime FechaCaducidad { get; set; }

    public virtual ICollection<Bitacora> Bitacoras { get; set; } = new List<Bitacora>();

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual Rol IdRolNavigation { get; set; } = null!;
}

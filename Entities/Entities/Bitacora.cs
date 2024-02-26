using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Bitacora
{
    public long IdBitacora { get; set; }

    public DateTime FechaHora { get; set; }

    public string Origen { get; set; } = null!;

    public string Mensaje { get; set; } = null!;

    public long IdUsuario { get; set; }

    public string DireccionIp { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}

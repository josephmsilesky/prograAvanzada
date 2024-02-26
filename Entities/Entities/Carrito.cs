using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Carrito
{
    public long IdCarrito { get; set; }

    public long IdUsuario { get; set; }

    public long IdCurso { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual Curso IdCursoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}

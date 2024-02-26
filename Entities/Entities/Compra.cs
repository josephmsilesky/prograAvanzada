using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Compra
{
    public long IdCompra { get; set; }

    public long IdUsuario { get; set; }

    public long IdCurso { get; set; }

    public DateTime FechaCompra { get; set; }

    public decimal PrecioPagado { get; set; }

    public virtual Curso IdCursoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}

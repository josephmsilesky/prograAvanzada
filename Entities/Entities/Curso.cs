using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Curso
{
    public long IdCurso { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public string Imagen { get; set; } = null!;

    public int IdCategoria { get; set; }

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual Categorium IdCategoriaNavigation { get; set; } = null!;
}

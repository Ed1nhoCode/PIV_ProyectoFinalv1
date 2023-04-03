using System;
using System.Collections.Generic;

namespace PIV_ProyectoFinalv1.Models;

public partial class CategoriaProducto
{
    public int IdCategoriaProducto { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}

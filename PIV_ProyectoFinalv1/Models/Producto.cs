using System;
using System.Collections.Generic;

namespace PIV_ProyectoFinalv1.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public int IdCategoria { get; set; }

    public string Descripcion { get; set; } = null!;

    public double Precio { get; set; }

    public bool Estado { get; set; }

    public int CantidadStock { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; } = new List<DetalleFactura>();

    public virtual CategoriaProducto IdCategoriaNavigation { get; set; } = null!;
}

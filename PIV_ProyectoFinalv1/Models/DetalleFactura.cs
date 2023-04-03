using System;
using System.Collections.Generic;

namespace PIV_ProyectoFinalv1.Models;

public partial class DetalleFactura
{
    public int IdDetalleFact { get; set; }

    public int IdFactura { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public double Precio { get; set; }

    public virtual Factura IdFacturaNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}

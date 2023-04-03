using System;
using System.Collections.Generic;

namespace PIV_ProyectoFinalv1.Models;

public partial class Factura
{
    public int IdFactura { get; set; }

    public int IdCliente { get; set; }

    public int IdPago { get; set; }

    public DateTime FechaFactura { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; } = new List<DetalleFactura>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual ModoPago IdPagoNavigation { get; set; } = null!;
}

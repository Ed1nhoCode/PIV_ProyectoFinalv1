using System;
using System.Collections.Generic;

namespace PIV_ProyectoFinalv1.Models;

public partial class ModoPago
{
    public int IdPago { get; set; }

    public string TipoPago { get; set; } = null!;

    public virtual ICollection<Factura> Facturas { get; } = new List<Factura>();
}

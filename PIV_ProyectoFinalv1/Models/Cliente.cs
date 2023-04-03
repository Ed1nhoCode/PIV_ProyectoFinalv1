using System;
using System.Collections.Generic;

namespace PIV_ProyectoFinalv1.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string NombreCliente { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public virtual ICollection<Factura> Facturas { get; } = new List<Factura>();
}

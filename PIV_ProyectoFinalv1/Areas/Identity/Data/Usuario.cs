using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PIV_ProyectoFinalv2.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Usuario class
public class Usuario : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "nvarchar(50)")]
    public string IdentificacionUsuario { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(50)")]
    public string NombreUsuario { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(50)")]
    public string TipoUsuario { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(50)")]
    public string EstadoUsuario { get; set; }
}


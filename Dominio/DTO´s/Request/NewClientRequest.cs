using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTO_s.Request;

public class NewClientRequest
{
    public string CodigoCliente { get; set; } // SCLIENT
    public DateTime? FechaNacimiento { get; set; } // DBIRTHDAT

    public string? Nombre { get; set; } // SFIRSTNAME
    public string? Apellido { get; set; } // SLASTNAME
    public string? SegundoApellido { get; set; } // SLASTNAME2
    public string? Cuit { get; set; } // SCUIT
    public string? NombreLegal { get; set; } // SLEGALNAME
    public string? NombreCompleto { get; set; } // SCLIENAME
    public string? Sexo { get; set; } // SSEXCLIEN

    public int? Nacionalidad { get; set; } // NNATIONALITY

}

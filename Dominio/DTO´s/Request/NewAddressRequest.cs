using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTO_s.Request;

public class NewAddressRequest
{
 
    public int PropRegistro { get; set; } // Nrecowner
    public string CodigoDireccion { get; set; } // Skeyaddress
    public DateOnly FechaEfectiva { get; set; } // Deffecdate
    public string IndicadorInformacion { get; set; }  // Sinfor
    public string Calle { get; set; } // Sstreet
    public int Altura { get; set; } // Nheight
    public string? Edificio { get; set; } // Sbuild
    public int? Piso { get; set; } // Nfloor
    public string? Departamento { get; set; } // Sdepartment
    public string? CodigoPostal { get; set; } // SzipCode
    public string? Ciudad { get; set; } // Szone
    public int Localidad { get; set; } // Nlocal
    public int Municipio { get; set; } // Nmunicipality
    public int Provincia { get; set; } // Nprovince
    public string? CorreoElectronico { get; set; } // SeMail
    public int? RamoComercial { get; set; } // Nbranch
    public int? Producto { get; set; } // Nproduct
    public int? NumPoliza { get; set; } // Npolicy

}

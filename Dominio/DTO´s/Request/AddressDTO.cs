using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTO_s.Request;

public class AddressDTO
{
    public int Nrecowner { get; set; }
    public string Skeyaddress { get; set; }
    public DateTime Deffecdate { get; set; }
    public string Sinfor { get; set; }
    public string Sstreet { get; set; }
    public int Nheight { get; set; }
    public string? Sbuild { get; set; }
    public int? Nfloor { get; set; }
    public string? Sdepartment { get; set; }
    public string? SzipCode { get; set; }
    public string? Szone { get; set; }
    public int Nlocal { get; set; }
    public int Nmunicipality { get; set; }
    public int Nprovince { get; set; }
    public string? SeMail { get; set; }
}

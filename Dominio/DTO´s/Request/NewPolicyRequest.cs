

namespace Dominio.DTO_s.Request;

public class NewPolicyRequest
{
    public int Ramo { get; set; }
    public int Producto { get; set; }
    public string ClienteId { get; set; } // SclientTitular
    public DateTime FechaInicio { get; set; } // Dstartdate
    public int FormaPago { get; set; } // Nway_pay
    public decimal Capital { get; set; } // Ncapital


}

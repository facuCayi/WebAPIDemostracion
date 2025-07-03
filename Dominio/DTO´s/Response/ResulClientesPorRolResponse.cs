using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTO_s.Response;

public class ResulClientesPorRolResponse
{
    public ClienteResponse Titular { get; set; } = new ClienteResponse();
    public ClienteResponse Asegurado { get; set; } = new ClienteResponse();
    public List<ClienteResponse> Beneficiarios { get; set; } = new List<ClienteResponse>();

}

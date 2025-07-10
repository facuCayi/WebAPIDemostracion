using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTO_s.Request;

public class PolizaRequest
{
    public int Nbranch { get; set; }
    public int Nproduct { get; set; }
    public int Npolicy { get; set; }
    public int Nway_pay { get; set; }
}

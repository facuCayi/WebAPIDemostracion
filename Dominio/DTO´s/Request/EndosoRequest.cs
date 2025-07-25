﻿using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTO_s.Request;

public class EndosoRequest
{
    public int IndiceTipoEndoso { get; set; }
    public DateTime FechaEndoso { get; set; }
    public PolizaRequest Poliza { get; set; }
    public string? Beneficiarios { get; set; }
    public AddressRequest? DireccionPostal { get; set; }
}

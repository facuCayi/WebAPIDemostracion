

using System;
using System.Reflection.PortableExecutable;

namespace Dominio.DTO_s.Response;

public class PolizaBuscarResponse
{
    public int NBRANCH { get; set; } 
    public int NPRODUCT { get; set; } 
    public int NPOLICY { get; set; }
    public string SCLIENT { get; set; } = string.Empty;
    public DateTime DDATE_ORIGI { get; set; }
    public DateTime DSTARTDATE { get; set; }
    public DateTime DEXPIRDAT { get; set; }
    public decimal NCAPITAL { get; set; }
    public DateTime DCOMPDATE { get; set; }
    public DateTime? DNULLDATE { get; set; } = null;
    public int? NNULLCODE { get; set; }
    public int? NUSERCODE { get; set; }
    public int NWAY_PAY { get; set; }

 }

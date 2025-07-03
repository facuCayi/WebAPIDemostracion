using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTO_s.Request;

public class AnularPolizaRequest
{
    public int Ramo { get; set; }             // NBRANCH
    public int Producto { get; set; }         // NPRODUCT
    public int NumeroPoliza { get; set; }     // NPOLICY
   // public int MotivoAnulacion { get; set; }  // NNULLCODE
    //public DateTime FechaAnulacion { get; set; } // DNULLDATE

}

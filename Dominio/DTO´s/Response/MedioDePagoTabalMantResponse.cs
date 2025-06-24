using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Models;

namespace Dominio.DTO_s.Response;

    public class MedioDePagoTabalMantResponse
    {
        public int NWay_Pay { get; set; }
        public string SDescript { get; set; }
        public DateTime DCompDate { get; set; } = DateTime.Now;
        public int NStatRegt { get; set; }
        public string SUserCode { get; set; } = string.Empty;
    }


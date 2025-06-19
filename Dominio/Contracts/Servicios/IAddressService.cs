using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contracts.Servicios
{
    public interface IAddressService
    {
        Task<Address> GetAddress(int nrecowner, string skeyaddress, string deffecdate, string sinfor);
        
    }
}

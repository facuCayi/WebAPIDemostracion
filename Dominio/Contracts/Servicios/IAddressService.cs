
using Dominio.DTO_s.Response;

namespace Dominio.Contracts.Servicios
{
    public interface IAddressService
    {
       AddressVisDatosResponse GetAddress(int nrecowner, string skeyaddress, string deffecdate, string sinfor);
        
    }
}

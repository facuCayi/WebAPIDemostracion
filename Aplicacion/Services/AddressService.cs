using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.Models;

namespace Aplicacion.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }
        public Task<Address> GetAddress(int nrecowner, string skeyaddress, string deffecdate, string sinfor)
        {
            return addressRepository.GetAddress(nrecowner, skeyaddress, deffecdate, sinfor);
        }
    }
    
    
}

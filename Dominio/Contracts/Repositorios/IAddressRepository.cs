using Dominio.Models;


namespace Dominio.Contracts.Repositorios
{
    public interface IAddressRepository 
    {
        Task<Address> GetAddress(int nrecowner, string skeyaddress, string deffecdate, string sinfor);
    }
}

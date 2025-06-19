using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface IClienteService
    {
        Task<Client> GetClientePorSclient(string scliente);
    }
}

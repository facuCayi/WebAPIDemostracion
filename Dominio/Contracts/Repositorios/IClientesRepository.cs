using Dominio.DTO_s.Request;
using Dominio.Models;

namespace Dominio.Contracts.Repositorios
{
    public interface IClientesRepository
    {
        Task<Client> GetClientePorSclient(string sclient);

        Task<bool> CreateJuridicClient(Client client);

        Task CreateClient(Client client); // Ver si hace falta

        void CambiarEstadoCliente(string clienteId);

        Task CambiarEstadoClienteAsync(string clienteId); // Asincronico, no llama al SP

        Task EditarClienteAsync(Client client); // Asincronico, no llama al SP

    }
}

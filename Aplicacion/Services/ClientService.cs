using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.Models;


namespace Aplicacion.Services
{
    public class ClientService : IClienteService
    {
        private readonly IClientesRepository clienteRepository;
        public ClientService(IClientesRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }
        public Task<Client> GetClientePorSclient(string sclient)
        {
            return clienteRepository.GetClientePorSclient(sclient);
        }
    }
}

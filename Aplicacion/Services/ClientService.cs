using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.DTO_s.Response;
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
        public ClienteFindResponse GetClientePorSclient(string sclient)
        {
            Client cliente = clienteRepository.GetClientePorSclient(sclient).Result;
            ClienteFindResponse clienteResponse = new ClienteFindResponse
            {
                SCLIENT = cliente.Sclient,
                DBIRTHDAT = cliente.Dbirthdat,
                SFIRSTNAME = cliente.Sfirstname,
                SLASTNAME = cliente.Slastname,
                SLASTNAME2 = cliente.Slastname2,
                SCUIT = cliente.Scuit,
                SLEGALNAME = cliente.Slegalname,
                SCLIENAME  = cliente.Scliename,
                SSEXCLIEN = cliente.Ssexclien,
                NNATIONALITY = cliente.Nnationality,
                NSTATREGT = cliente.Nstatregt,
                DCOMPDATE = cliente.Dcompdate,
                NUSERCODE = cliente.Nusercode
            };
            return clienteResponse;
        }
    }
}

using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.DTO_s.Request;
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
                SCLIENAME = cliente.Scliename,
                SSEXCLIEN = cliente.Ssexclien,
                NNATIONALITY = cliente.Nnationality,
                NSTATREGT = cliente.Nstatregt,
                DCOMPDATE = cliente.Dcompdate,
                NUSERCODE = cliente.Nusercode
            };
            return clienteResponse;
        }

        public bool CreateJuridicClient(NewClientJuridicoRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null");
            }
            Client client = new Client
            {
                Sclient = request.RucCUIT,
                Slegalname = request.RazonSocial,
                Scuit = request.RucCUIT,
                Nnationality = request.Nacionalidad,
                Dbirthdat = request.FechaConstitucion.ToDateTime(new TimeOnly(0, 0)),
                Sfirstname = null,
                Slastname = null,
                Slastname2 = null,
                Ssexclien = null
            };
            return clienteRepository.CreateJuridicClient(client).Result;
        }

        public void CambiarEstadoCliente(string clienteId)
        {
            if (string.IsNullOrWhiteSpace(clienteId))
            {
                throw new ArgumentNullException(nameof(clienteId), "Request cannot be null");
            }

            try
            {
                clienteRepository.CambiarEstadoCliente(clienteId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar estado cliente", ex);
            }
        }


        public Task CambiarEstadoClienteAsync(string clienteId)
        {

            if (string.IsNullOrWhiteSpace(clienteId))
            {
                throw new ArgumentNullException(nameof(clienteId), "Request cannot be null");
            }


            return clienteRepository.CambiarEstadoClienteAsync(clienteId);
        }

        public Task EditarClienteAsync(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client), "Client cannot be null");
            }
            return clienteRepository.EditarClienteAsync(client);
        }

        public async Task<ResulClientesPorRolResponse> GetClientesPorRolAsync(int Nbranch, int Nproduct, int Npolicy)
        {
            
            return await clienteRepository.BuscarClientesPorRol(Nbranch, Nproduct, Npolicy);
        }
    }
}

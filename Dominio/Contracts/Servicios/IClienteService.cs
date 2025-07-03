using Dominio.DTO_s.Request;
using Dominio.DTO_s.Response;
using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface IClienteService
    {
        ClienteFindResponse GetClientePorSclient(string scliente);
        bool CreateJuridicClient(NewClientJuridicoRequest request);

        void CambiarEstadoCliente(string clienteId);

        Task CambiarEstadoClienteAsync(string clienteId);

        Task EditarClienteAsync(Client client);

        Task<ResulClientesPorRolResponse> GetClientesPorRolAsync(int rama, int producto, int poliza);
    }
}

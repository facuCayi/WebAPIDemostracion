using Dominio.DTO_s.Response;
using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface IClienteService
    {
        ClienteFindResponse GetClientePorSclient(string scliente);
    }
}

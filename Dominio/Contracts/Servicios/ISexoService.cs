using Dominio.DTO_s.Response;

using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface ISexoService
    {
        List<SexoDDLResponse> GetAll();
    }
}

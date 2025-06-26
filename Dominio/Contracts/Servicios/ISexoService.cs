using Dominio.DTO_s.Response;

namespace Dominio.Contracts.Servicios
{
    public interface ISexoService
    {
        List<SexoDDLResponse> GetAll();
    }
}

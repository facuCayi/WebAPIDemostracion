using Dominio.DTO_s.Response;
using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface IMunicipalityService
    {
        List<ClaseDDLResponse> GetAll();
        List<ClaseDDLResponse> GetByProvince(int nprovince);
    }
}

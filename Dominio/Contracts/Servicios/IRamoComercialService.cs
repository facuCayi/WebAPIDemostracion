using Dominio.DTO_s.Response;

namespace Dominio.Contracts.Servicios
{
    public interface IRamoComercialService
    {
        List<RamoComercialDDLResponse> GetAll();
    }
}

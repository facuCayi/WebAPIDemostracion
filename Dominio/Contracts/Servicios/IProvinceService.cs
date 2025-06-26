using Dominio.Models;
using Dominio.DTO_s.Response;


namespace Dominio.Contracts.Servicios
{

    public interface IProvinceService
    {
        List<ClaseDDLResponse> GetAll();
    }
}

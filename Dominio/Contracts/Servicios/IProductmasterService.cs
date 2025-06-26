using Dominio.DTO_s.Response;
using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface IProductmasterService
    {
        List<ClaseDDLResponse> GetAll();

        List<ClaseDDLResponse> GetProductosPorRama(int nbranch);
    }
}

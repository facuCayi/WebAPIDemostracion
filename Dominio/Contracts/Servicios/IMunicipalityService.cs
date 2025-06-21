using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface IMunicipalityService
    {
        Task<List<Municipality>> GetAll();
        Task<List<Municipality>> GetByProvince(int nprovince);
    }
}

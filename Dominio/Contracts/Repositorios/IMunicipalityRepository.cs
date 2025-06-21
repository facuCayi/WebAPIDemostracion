using Dominio.Models;

namespace Dominio.Contracts.Repositorios
{
    public interface IMunicipalityRepository
    {
        Task<List<Municipality>> GetAll();
        Task<List<Municipality>> GetByProvince(int nprovince);
    }
}

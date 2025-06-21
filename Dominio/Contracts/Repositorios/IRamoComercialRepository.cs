using Dominio.Models;

namespace Dominio.Contracts.Repositorios
{
    public interface IRamoComercialRepository
    {
        Task<List<RamoComercial>> GetAll();
    }
}

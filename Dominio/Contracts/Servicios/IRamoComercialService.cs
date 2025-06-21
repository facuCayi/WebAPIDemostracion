using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface IRamoComercialService
    {
        Task<List<RamoComercial>> GetAll();
    }
}

using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface IPolicyHistoryService
    {
        Task<List<PolicyHistory>> GetAll();
    }
}

using Dominio.Models;

namespace Dominio.Contracts.Repositorios
{
    public interface IPolicyHistoryRepository
    {
        Task<List<PolicyHistory>> GetAll();
    }
}

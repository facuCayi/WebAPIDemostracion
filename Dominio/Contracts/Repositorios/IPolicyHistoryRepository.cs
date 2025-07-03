using Dominio.DTO_s.Response;
using Dominio.Models;

namespace Dominio.Contracts.Repositorios
{
    public interface IPolicyHistoryRepository
    {


        Task<(List<PolicyHistory> historial, string rama, string producto)> GetHistorialPolizaCompleto(int nbranch, int nproduct, int npolicy);
    }
}

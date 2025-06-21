using Dominio.Models;

namespace Dominio.Contracts.Repositorios
{
    public interface IPremiumRepository
    {
        Task<List<Premium>> GetPremiumsPorPolizas(int nbranch, int nproduct, int npolicy);
        Task<List<Premium>> GetAll();
        Task<List<Premium>> GetPremiumsPorEnvioACobro(int nway_pay);
    }
}

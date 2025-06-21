using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface IPremiumService
    {
        Task<List<Premium>> GetPremiumsPorPolizas(int nbranch, int nproduct, int npolicy);
        Task<List<Premium>> GetAll();
        Task<List<Premium>> GetPremiumsPorEnvioACobro(int nway_pay);
    }
}

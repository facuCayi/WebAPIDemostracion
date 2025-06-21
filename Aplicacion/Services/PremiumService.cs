using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.Models;

namespace Aplicacion.Services
{
    public class PremiumService : IPremiumService
    {
        private readonly IPremiumRepository _premiumRepository;
        public PremiumService(IPremiumRepository premiumRepository)
        {
            _premiumRepository = premiumRepository;
        }

        public Task<List<Premium>> GetAll()
        {
            return _premiumRepository.GetAll();
        }

        public Task<List<Premium>> GetPremiumsPorEnvioACobro(int nway_pay)
        {
            return _premiumRepository.GetPremiumsPorEnvioACobro(nway_pay);
        }

        public Task<List<Premium>> GetPremiumsPorPolizas(int nbranch, int nproduct, int npolicy)
        {
            return _premiumRepository.GetPremiumsPorPolizas(nbranch, nproduct, npolicy);
        }
    }
}

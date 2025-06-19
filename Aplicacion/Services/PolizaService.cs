using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.Models;

namespace Aplicacion.Services
{
    public class PolizaService : IPolizaService
    {

        private readonly IPolizaRepository polizaRepository;
        public PolizaService(IPolizaRepository polizaRepository)
        {
            this.polizaRepository = polizaRepository;
        }

        public Task<List<Poliza>> GetAll()
        {
            return polizaRepository.GetAll();
        }

        public Task<List<Poliza>> GetPolizasByUserCode(string sclient)
        {
            return polizaRepository.GetPolizasByUserCode(sclient);
        }
    }
}

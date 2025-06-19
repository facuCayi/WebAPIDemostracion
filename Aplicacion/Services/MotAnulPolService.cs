using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.Models;

namespace Aplicacion.Services
{
    public class MotAnulPolService : IMotAnulPolService
    {
        private readonly IMotAnulPolRepository motAnulPolRepository;
        public MotAnulPolService(IMotAnulPolRepository motAnulPolRepository)
        {
            this.motAnulPolRepository = motAnulPolRepository;
        }
        public Task<List<MotAnulacionPoliza>> GetAll()
        {
            return motAnulPolRepository.GetAll();
        }
    }
}

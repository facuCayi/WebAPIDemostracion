using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.Models;

namespace Aplicacion.Services
{
    public class MotAnulRecService : IMotAnulRecService
    {

        private readonly IMotAnulRecRepository motAnulRecRepository;

        public MotAnulRecService(IMotAnulRecRepository motAnulRecRepository)
        {
            this.motAnulRecRepository = motAnulRecRepository;
        }

        public Task<List<MotAnulacionRecibo>> GetAll()
        {
           return motAnulRecRepository.GetAll();
        }
    }
}

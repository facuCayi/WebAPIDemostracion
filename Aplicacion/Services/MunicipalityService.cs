using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.Models;

namespace Aplicacion.Services
{
    public class MunicipalityService : IMunicipalityService
    {
        private readonly IMunicipalityRepository municipalityRepository;
        public MunicipalityService(IMunicipalityRepository municipalityRepository)
        {
            this.municipalityRepository = municipalityRepository;
        }
        public Task<List<Municipality>> GetAll()
        {
            return municipalityRepository.GetAll();
        }

        public Task<List<Municipality>> GetByProvince(int nprovince)
        {
            return municipalityRepository.GetByProvince(nprovince);
        }
    }
}

using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.DTO_s.Response;
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
        public List<ClaseDDLResponse> GetAll()
        {
            List<Municipality> municipalities = municipalityRepository.GetAll().Result;
            List<ClaseDDLResponse> response = municipalities.Select(m => new ClaseDDLResponse
            {
                NCODIGO = m.Nmunicipality,
                SDESCRIPT = m.Sdescript == null ? string.Empty : m.Sdescript.Trim()
            }).ToList();
            return response;
        }

        public List<ClaseDDLResponse> GetByProvince(int nprovince)
        {
            List<Municipality> municipalities = municipalityRepository.GetByProvince(nprovince).Result;
            List<ClaseDDLResponse> response = municipalities.Select(m => new ClaseDDLResponse
            {
                NCODIGO = m.Nmunicipality,
                SDESCRIPT = m.Sdescript == null ? string.Empty : m.Sdescript.Trim()
            }).ToList();

            return response;
        }
    }
}

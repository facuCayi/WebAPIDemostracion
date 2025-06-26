using Dominio.Models;
using Dominio.Contracts.Servicios;
using Dominio.Contracts.Repositorios;
using Dominio.DTO_s.Response;

namespace Aplicacion.Services
{
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository _provinceRepository;

        public ProvinceService(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }
        public List<ClaseDDLResponse> GetAll()
        {
            List<Province> provinces = _provinceRepository.GetAll().Result;
            List<ClaseDDLResponse> response =provinces.Select(p => new ClaseDDLResponse
            {
                NCODIGO = p.Nprovince,
                SDESCRIPT = p.Sdescript == null ? string.Empty : p.Sdescript.Trim()
            }).ToList();
            return response ;
        }
    }
}

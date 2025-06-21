using Dominio.Models;
using Dominio.Contracts.Servicios;
using Dominio.Contracts.Repositorios;

namespace Aplicacion.Services
{
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository _provinceRepository;

        public ProvinceService(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }
        public Task<List<Province>> GetAll()
        {
             return _provinceRepository.GetAll();
        }
    }
}

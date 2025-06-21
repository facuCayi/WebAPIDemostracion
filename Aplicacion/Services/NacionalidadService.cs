using Dominio.Contracts.Servicios;
using Dominio.Models;
using Dominio.Contracts.Repositorios;

namespace Aplicacion.Services
{
    public class NacionalidadService : INacionalidadService
    {
        private readonly INacionalidadRepository _nacionalidadRepository;
        public NacionalidadService(INacionalidadRepository nacionalidadRepository)
        {
            _nacionalidadRepository = nacionalidadRepository;
        }
        public  Task<List<Nacionalidad>> GetAll()
        {
            return _nacionalidadRepository.GetAll();
        }
    }
}

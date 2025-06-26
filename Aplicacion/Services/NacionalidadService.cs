using Dominio.Contracts.Servicios;
using Dominio.Models;
using Dominio.Contracts.Repositorios;
using Dominio.DTO_s.Response;

namespace Aplicacion.Services
{
    public class NacionalidadService : INacionalidadService
    {
        private readonly INacionalidadRepository _nacionalidadRepository;
        public NacionalidadService(INacionalidadRepository nacionalidadRepository)
        {
            _nacionalidadRepository = nacionalidadRepository;
        }
        public  List<ClaseDDLResponse> GetAll()
        {
            List<Nacionalidad> nacionalidades = _nacionalidadRepository.GetAll().Result;
            List<ClaseDDLResponse> response = nacionalidades.Select(n => new ClaseDDLResponse
            {
                NCODIGO = n.Nnationality,
                SDESCRIPT = n.Sdescript == null ? string.Empty : n.Sdescript.Trim()
            }).ToList();

            return response;
        }
    }
}

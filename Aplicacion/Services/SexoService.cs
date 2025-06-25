using Dominio.Contracts.Servicios;
using Dominio.Models;
using Dominio.Contracts.Repositorios;
using Dominio.DTO_s.Response;


namespace Aplicacion.Services
{
    public class SexoService : ISexoService
    {
        private readonly ISexoRepository sexoRepository;
        public SexoService(ISexoRepository sexoRepository)
        {
            this.sexoRepository = sexoRepository;
        }
      
       public List<SexoDDLResponse> GetAll()
        {
           List<Sexo> sexos = this.sexoRepository.GetAll().Result;      
           List<SexoDDLResponse> response = sexos.Select(s => new SexoDDLResponse
            {
                SSEXCLIEN = s.Ssexclien,
                SDESCRIPT = s.Sdescript == null ? string.Empty : s.Sdescript.Trim()
            }).ToList();
            return response;

        }

    }
    
}

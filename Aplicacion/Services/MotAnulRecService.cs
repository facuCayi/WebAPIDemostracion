using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.DTO_s.Response;
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

        public List<ClaseDDLResponse> GetAll()
        {
           List<MotAnulacionRecibo> motivos = motAnulRecRepository.GetAll().Result;
            List<ClaseDDLResponse> response = motivos.Select(m => new ClaseDDLResponse
            {
                NCODIGO = m.Nnullcode,
                SDESCRIPT = m.Sdescript == null ? string.Empty : m.Sdescript.Trim()
            }).ToList();
            return response;
        }
    }
}

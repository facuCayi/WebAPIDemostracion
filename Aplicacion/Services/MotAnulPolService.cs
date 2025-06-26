using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.DTO_s.Response;
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
        public List<ClaseDDLResponse> GetAll()
        {
            List<MotAnulacionPoliza> motivos = motAnulPolRepository.GetAll().Result;
            List<ClaseDDLResponse> response = motivos.Select(x => new ClaseDDLResponse
            {
                NCODIGO = x.Nnullcode,
                SDESCRIPT = x.Sdescript == null ? string.Empty : x.Sdescript.Trim()
            }).ToList();
            return response;
        }
  
    }
}

using Dominio.Contracts.Servicios;
using Dominio.Models;
using Dominio.Contracts.Repositorios;
using Dominio.DTO_s.Response;



namespace Aplicacion.Services
{
    public class RamoComercialService : IRamoComercialService
    {
        private readonly IRamoComercialRepository _ramoComercialRepository;
        public RamoComercialService(IRamoComercialRepository ramoComercialRepository)
        {
            _ramoComercialRepository = ramoComercialRepository;
        }
        public  List<RamoComercialDDLResponse> GetAll()
        {
            List<RamoComercial> ramoComerciales = _ramoComercialRepository.GetAll().Result;
            List<RamoComercialDDLResponse> response = ramoComerciales.Select(rc => new RamoComercialDDLResponse
            {
                NBRANCH = rc.Nbranch,
                SDESCRIPT = rc.Sdescript == null ? string.Empty : rc.Sdescript.Trim()
            }).ToList();
            return response;
        }

    }
}

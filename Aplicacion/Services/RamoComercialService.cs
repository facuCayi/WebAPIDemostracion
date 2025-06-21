using Dominio.Contracts.Servicios;
using Dominio.Models;
using Dominio.Contracts.Repositorios;


namespace Aplicacion.Services
{
    public class RamoComercialService : IRamoComercialService
    {
        private readonly IRamoComercialRepository _ramoComercialRepository;
        public RamoComercialService(IRamoComercialRepository ramoComercialRepository)
        {
            _ramoComercialRepository = ramoComercialRepository;
        }
        public  Task<List<RamoComercial>> GetAll()
        {
            return  _ramoComercialRepository.GetAll();
        }

    }
}

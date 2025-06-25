using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Dominio.Contracts.Servicios;
using Dominio.DTO_s.Response;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamoComercialController : ControllerBase
    {
        private readonly IRamoComercialService ramoService;
        public RamoComercialController(IRamoComercialService ramoService)
        {
            this.ramoService = ramoService;
        }

        //GET: api/RamoComercial
        [HttpGet]
        public ActionResult<IEnumerable<RamoComercialDDLResponse>> GetRamos()
        {
            ActionResult<IEnumerable<RamoComercialDDLResponse>> result;
            try
            {
                List<RamoComercialDDLResponse> ramos = ramoService.GetAll();

                result =  Ok(ramos);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, $"Error al lista ramos comericales: {ex.Message}");
            }

            return result;

        }
    }
}

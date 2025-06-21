using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Dominio.Contracts.Servicios;

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
        public async Task<ActionResult<IEnumerable<RamoComercial>>> GetRamos()
        {
            ActionResult result;
            try
            {
                var ramos = await ramoService.GetAll();

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

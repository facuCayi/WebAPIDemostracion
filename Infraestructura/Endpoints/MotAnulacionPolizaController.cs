using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Dominio.Contracts.Servicios;

namespace Infraestructura.Endpoints
{

    [Route("api/[controller]")]
    [ApiController]
    public class MotAnulacionPolizaController : ControllerBase
    {
        private readonly IMotAnulPolService motAnulPolService;
        public MotAnulacionPolizaController(IMotAnulPolService motAnulPolService)
        {
            this.motAnulPolService = motAnulPolService;
        }

        //GET: api/MotAnulacionPoliza
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotAnulacionPoliza>>> GetMotAnulacionPoliza()
        {
            ActionResult result;
            try
            {
                var motivos = await motAnulPolService.GetAll();

                result =  Ok(motivos);

            }
            catch (Exception ex)
            {
                result =  StatusCode(500, $"Error al lista motivos anulación póliza: {ex.Message}");
            }

            return result;
        }
    }
}

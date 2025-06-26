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
    public class MotAnulacionPolizaController : ControllerBase
    {
        private readonly IMotAnulPolService motAnulPolService;
        public MotAnulacionPolizaController(IMotAnulPolService motAnulPolService)
        {
            this.motAnulPolService = motAnulPolService;
        }

        //GET: api/MotAnulacionPoliza
        [HttpGet]
        public ActionResult<IEnumerable<ClaseDDLResponse>> GetMotAnulacionPoliza()
        {
            ActionResult<IEnumerable<ClaseDDLResponse>> result;
            try
            {
                List<ClaseDDLResponse> motivos = motAnulPolService.GetAll();

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

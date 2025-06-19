using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Dominio.Contracts.Servicios;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotAnulacionReciboController : ControllerBase
    {

        private readonly IMotAnulRecService motAnulRecService;
        public MotAnulacionReciboController(IMotAnulRecService motAnulRecService)
        {
            this.motAnulRecService = motAnulRecService;
        }

        //GET: api/MotAnulacionRecibo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotAnulacionRecibo>>> GetMotAanulRecibos()
        {
            ActionResult result;
            try
            {
                var motivoAnulRecibos = await motAnulRecService.GetAll();

                result = Ok(motivoAnulRecibos);

            }
            catch (Exception ex)
            {
                result =  StatusCode(500, $"Error al listar motivo anulacion recibos: {ex.Message}");
            }

            return result;
        }
    }
}

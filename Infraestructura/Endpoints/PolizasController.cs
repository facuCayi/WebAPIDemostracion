using Dominio.Contracts.Servicios;
using Dominio.Models;
using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolizasController : ControllerBase
    {
        private readonly IPolizaService polizaService;
        public PolizasController(IPolizaService polizaService)
        {
            this.polizaService = polizaService;
        }

        // GET: api/polizas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poliza>>> GetPolizas()
        {
            ActionResult result;
            try
            {
                var polizas = await polizaService.GetAll();

                result =  Ok(polizas);
            }
            catch (Exception ex)
            {
                result =  StatusCode(500, $"Error al obtener pólizas: {ex.Message}");
            }

            return result;
        }

        // GET: api/polizas/cliente/{sclient}
        [HttpGet("cliente/{sclient}")]
        public async Task<ActionResult<IEnumerable<Poliza>>> GetPolizasPorCliente(string sclient)
        {
            ActionResult result;
            try
            {
                var polizas = await polizaService.GetPolizasByUserCode(sclient);

                result = Ok(polizas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al filtrar polizas por cliente: {ex.Message}");
            }

            return result;
        }

    }
}

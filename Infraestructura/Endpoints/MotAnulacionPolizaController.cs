using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Endpoints
{

    [Route("api/[controller]")]
    [ApiController]
    public class MotAnulacionPolizaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MotAnulacionPolizaController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/MotAnulacionPoliza
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotAnulacionPoliza>>> GetMotAnulacionPoliza()
        {
            try
            {
                var motivos = await _context.MotAnulacionPolizas.ToListAsync();

                return Ok(motivos);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al lista motivos anulación póliza: {ex.Message}");
            }
        }
    }
}

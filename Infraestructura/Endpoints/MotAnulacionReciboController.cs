using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotAnulacionReciboController : ControllerBase
    {

        private readonly AppDbContext _context;
        public MotAnulacionReciboController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/MotAnulacionRecibo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotAnulacionRecibo>>> GetMotAanulRecibos()
        {
            try
            {
                var motivoAnulRecibos = await _context.MotAnulacionRecibos.ToListAsync();

                return Ok(motivoAnulRecibos);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar motivo anulacion recibos: {ex.Message}");
            }
        }
    }
}

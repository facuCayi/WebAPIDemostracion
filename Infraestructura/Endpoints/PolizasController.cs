using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolizasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PolizasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/polizas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poliza>>> GetPolizas()
        {
            try
            {
                var polizas = await _context.Polizas
                    .Include(p => p.Client)
                    .Include(p => p.Way_pay)
                    .Include(p => p.NullCode)
                    .Include(p => p.Usuario)
                    .Include(p => p.Product)
                    .ToListAsync();


                return Ok(polizas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener pólizas: {ex.Message}");
            }
        }

        // GET: api/polizas/cliente/{sclient}
        [HttpGet("cliente/{sclient}")]
        public async Task<ActionResult<IEnumerable<Poliza>>> GetPolizasPorCliente(string sclient)
        {
            try
            {
                var polizas = await _context.Polizas
                    .Include(p => p.Client)
                    .Include(p => p.Way_pay)
                    .Include(p => p.NullCode)
                    .Include(p => p.Usuario)
                    .Include(p => p.Product)
                    .Where(c => c.Sclient == sclient)
                    .ToListAsync();

                return Ok(polizas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al filtrar polizas por cliente: {ex.Message}");
            }
        }

    }
}

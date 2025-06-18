using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Endpoints
{

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/clientes/{sclient}
        [HttpGet("{sclient}")]
        public async Task<ActionResult<Client>> GetClientePorSclient(string sclient)
        {
            try
            {
                var cliente = await _context.Clients
                .Include(c => c.Sex)
                .Include(c => c.Nacionality)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(c => c.Sclient == sclient);

                if (cliente == null)
                    return NotFound($"No se encontró el cliente con SCLIENT: {sclient}");

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener cliente: {ex.Message}");
            }
        }
    }
}
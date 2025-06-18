using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tab_LocatController : ControllerBase
    {
        private readonly AppDbContext _context;
        public Tab_LocatController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/Tab_locat

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tab_locat>>> GetTab_locats()
        {
            try
            {
                var localidades = await _context.Tab_Locats.ToListAsync();
                return Ok(localidades);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener localidades: {ex.Message}");
            }
        }
    }
}

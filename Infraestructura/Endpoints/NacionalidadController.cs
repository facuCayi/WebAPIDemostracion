using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class NacionalidadController : ControllerBase
    {
        private readonly AppDbContext _context;
        public NacionalidadController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/Nacionalidad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nacionalidad>>> GetNacionalidades()
        {
            try
            {
                var nacionalidades = await _context.Nacionalidades.ToListAsync();

                return Ok(nacionalidades);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar nacionalidades: {ex.Message}");
            }
        }
    }
}

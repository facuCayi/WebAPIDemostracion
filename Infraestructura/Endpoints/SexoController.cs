using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class SexoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SexoController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/Sexo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sexo>>> GetSexos()
        {
            try
            {
                var sexos = await _context.Sexos.ToListAsync();

                return Ok(sexos);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al lista sexos: {ex.Message}");
            }
        }
    }
}

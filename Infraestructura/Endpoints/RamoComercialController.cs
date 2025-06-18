using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class RamoComercialController : ControllerBase
    {
        private readonly AppDbContext _context;
        public RamoComercialController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/RamoComercial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RamoComercial>>> GetRamos()
        {
            try
            {
                var ramos = await _context.RamoComercials.ToListAsync();

                return Ok(ramos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al lista ramos comericales: {ex.Message}");
            }
        
        }
    }
}

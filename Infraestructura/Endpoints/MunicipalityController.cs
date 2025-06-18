using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;


namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalityController : Controller
    {
        private readonly AppDbContext _context;

        public MunicipalityController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/municipality
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Municipality>>> GetMunicipalities()
        {
            try
            {
                var municipalities = await _context.Municipalities
                    .Include(p => p.Provincia)
                    .ToListAsync();
                return Ok(municipalities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener municipalidades: {ex.Message}");
            }
        }

        // GET: api/municipality/province/{nprovince}
        [HttpGet("{nprovince}")]
        public async Task<ActionResult<IEnumerable<Municipality>>> GetMunicipalityPorNProvince(int nprovince)
        {
            try
            {
                var municipalidad = await _context.Municipalities
                   .Include (p => p.Provincia)
                  .Where(m => m.Nprovince == nprovince)
                  .ToListAsync();

                return Ok(municipalidad);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener municipalidades: {ex.Message}");
            }
        }
    }
}

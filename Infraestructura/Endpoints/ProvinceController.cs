using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProvinceController(AppDbContext context)
        { 
            _context = context;
        }

        //GET: api/province
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Province>>> GetProvinces()
        {
            try
            {
                var provinces = await _context.Provinces
                    .Include(c => c.Usuario)
                    .ToListAsync();
                return Ok(provinces);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener provincias: {ex.Message}");
            }
        }


    }
}

using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;


namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductmasterController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductmasterController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/productmaster/{nbranch}
        [HttpGet("{nbranch}")]
        public async Task<ActionResult<IEnumerable<Productmaster>>> GetProductosPorRama(int nbranch)
        {
            try
            {
                var productos = await _context.Productmasters
                    .Include(p => p.Branch)
                    .Include(p => p.Usuario)
                    .Where(p => p.Nbranch == nbranch)
                    .ToListAsync();

                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los productos por rama: {ex.Message}");
            }
        }

        //GET: api/productmaster}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productmaster>>> GetProductos()
        {
            try
            {
                var productos = await _context.Productmasters
                    .Include(p => p.Branch)
                    .Include(p => p.Usuario)
                    .ToListAsync();

                return Ok(productos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar los productos : {ex.Message}");
            }
        }

    }
}

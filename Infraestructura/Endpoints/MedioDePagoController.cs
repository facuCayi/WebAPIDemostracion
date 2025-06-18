using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedioDePagoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MedioDePagoController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/MedioDePago
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedioDePago>>> GetMediosDePago()
        {
            try
            {
                var mediosDePago = await _context.MediosDePago.ToListAsync();

                return Ok(mediosDePago);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar medios de pago: {ex.Message}");
            }
        }
    }
}

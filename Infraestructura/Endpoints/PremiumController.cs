using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumController : Controller
    {
        private readonly AppDbContext _context;

        public PremiumController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/premium/{nbranch}/{nproduct}/{npolicy}}
        [HttpGet("premium/{nbranch}/{nproduct}/{npolicy}")]
        public async Task<ActionResult<IEnumerable<Premium>>> GetPremiumsPorPolizas(int nbranch, int nproduct, int npolicy)
        {
            try
            {
                var premiums = await _context.Premiums
                    .Where(p =>
                    p.Nbranch == nbranch &&
                    p.Nproduct == nproduct &&
                    p.Npolicy == npolicy 
                    )
                    .ToListAsync();

                return Ok(premiums);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener premios por póliza: {ex.Message}");

            }
        }

        //GET: api/premium
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Premium>>> GetPremiums()
        {
            try
            {
                var premiums = await _context.Premiums.ToListAsync();

                return Ok(premiums);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar recibos: {ex.Message}");
            }
        }

        //GET: api/premium/{nway_pay}
        [HttpGet("premium/{nway_pay}")]
        public async Task<ActionResult<IEnumerable<Premium>>> GetPremiumsPorEnvioACobro(int nway_pay)
        {
            try
            {
                var premiums = await _context.Premiums
                    .Where(p =>
                    p.Nway_pay == nway_pay
                    )
                    .ToListAsync();

                return Ok(premiums);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar recibos por envio a cobro: {ex.Message}");
            }
        }


    }
}

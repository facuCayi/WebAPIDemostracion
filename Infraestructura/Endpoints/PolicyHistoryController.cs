using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyHistoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PolicyHistoryController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/PolicyHistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PolicyHistory>>> GetPolicyHistorys()
        {
            try
            {
                var historiales = await _context.PolicyHistories
                    .Include(p => p.Client)
                    .Include(p => p.Way_pay)
                    .Include(p => p.NullCode)
                    .Include(p => p.Usuario)
                    .Include(p => p.Branch)
                    .Include(p => p.Product)
                    .ToListAsync();

                return Ok(historiales);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar historiales de poliza: {ex.Message}");
            }
        }
    }
}

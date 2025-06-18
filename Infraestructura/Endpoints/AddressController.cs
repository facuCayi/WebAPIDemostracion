using Dominio.Models;
using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AddressController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/address/{nrecowner}/{skeyaddress}/{sinfor}
        [HttpGet("address/{nrecowner}/{skeyaddress}/{deffecdate}/{sinfor}")]
        public async Task<ActionResult<Address>> GetAddress(int nrecowner, string skeyaddress, string deffecdate, string sinfor)
        {
            DateTime fecha;
            if (!DateTime.TryParseExact(deffecdate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out fecha))

                return BadRequest("Formato de fecha inválido. Usá yyyy-MM-dd.");
            try
            {  
               // DateTime fechaInicio = fecha.Date;
                //DateTime fechaFin = fechaInicio.AddDays(1);

                var address = await _context.Addresses
                    .Where(a =>
                        a.Nrecowner == nrecowner &&
                        a.Skeyaddress.Trim() == skeyaddress.Trim() &&
                        a.Sinfor.Trim() == sinfor.Trim() &&
                        a.Deffecdate.Date == fecha.Date
                       // a.Deffecdate == fechaInicio &&
                       // a.Deffecdate < fechaFin
                    )
                    .FirstOrDefaultAsync();

                if (address == null)
                    return StatusCode(200, $"Dirección no existe");

                return Ok(address);
    
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al filtrar por dirección: {ex.Message}");
            }
        }
    }
}

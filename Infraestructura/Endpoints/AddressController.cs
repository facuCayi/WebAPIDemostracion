using Dominio.Contracts.Servicios;
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
        private readonly IAddressService addressService;

        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }
        // GET: api/address/{nrecowner}/{skeyaddress}/{sinfor}
        [HttpGet("address/{nrecowner}/{skeyaddress}/{deffecdate}/{sinfor}")]
        public async Task<ActionResult<Address>> GetAddress(int nrecowner, string skeyaddress, string deffecdate, string sinfor)
        {
            ActionResult result;
            try
            {  
               // DateTime fechaInicio = fecha.Date;
                //DateTime fechaFin = fechaInicio.AddDays(1);

                var address = await addressService.GetAddress(nrecowner, skeyaddress, deffecdate, sinfor);

                result = Ok(address);
    
            }
            catch (Exception ex)
            {
                result =  StatusCode(500, $"Error al filtrar por dirección: {ex.Message}");
            }

            return result;
        }
    }
}

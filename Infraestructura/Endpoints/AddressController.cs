using Aplicacion.Services;
using Dominio.Contracts.Servicios;
using Dominio.DTO_s.Request;
using Dominio.DTO_s.Response;
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
        public ActionResult<AddressVisDatosResponse> GetAddress(int nrecowner, string skeyaddress, string deffecdate, string sinfor)
        {
            ActionResult<AddressVisDatosResponse> result;
            try
            {
                // DateTime fechaInicio = fecha.Date;
                //DateTime fechaFin = fechaInicio.AddDays(1);

                AddressVisDatosResponse addressResponse =addressService.GetAddress(nrecowner, skeyaddress, deffecdate, sinfor);

                result = Ok(addressResponse);
    
            }
            catch (Exception ex)
            {
                result =  StatusCode(500, $"Error al filtrar por dirección: {ex.Message}");
            }

            return result;
        }

        [HttpPost("new")]

        public ActionResult<bool> CreateAddress([FromBody] NewAddressRequest request)
        {
            ActionResult result;
            try
            {
                addressService.CreateAddress(request);

                result = Ok(true); // Retorna true si la creación fue exitosa
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.Message); // Manejo de errores
            }
            return result;

        }

    }
}

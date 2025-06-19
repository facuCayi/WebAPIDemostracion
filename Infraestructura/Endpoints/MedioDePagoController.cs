using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Dominio.Contracts.Servicios;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedioDePagoController : ControllerBase
    {
        private readonly IMedioDePagoService medioDePagoService;

        public MedioDePagoController(IMedioDePagoService medioDePagoService)
        {
            this.medioDePagoService = medioDePagoService;
        }

        //GET: api/MedioDePago
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedioDePago>>> GetMediosDePago()
        {
            ActionResult result;
            try
            {
                var mediosDePago = await medioDePagoService.GetAll();

                result =  Ok(mediosDePago);

            }
            catch (Exception ex)
            {
                result = StatusCode(500, $"Error al listar medios de pago: {ex.Message}");
            }

            return result;
        }
    }
}

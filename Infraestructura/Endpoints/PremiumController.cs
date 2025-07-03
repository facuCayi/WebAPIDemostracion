using Dominio.Contracts.Servicios;
using Dominio.DTO_s.Response;
using Dominio.Models;
using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumController : Controller
    {
        private readonly IPremiumService premiumService;

        public PremiumController(IPremiumService premiumService)
        {
            this.premiumService = premiumService;
        }

        //GET: api/premium/{nbranch}/{nproduct}/{npolicy}}
        [HttpGet("{nbranch}/{nproduct}/{npolicy}")]
        public ActionResult<IEnumerable<ReciboResponse>> GetPremiumsPorPolizas(int nbranch, int nproduct, int npolicy)
        {
            ActionResult<IEnumerable<ReciboResponse>> result;
            try
            {
                List<ReciboResponse> premiums = premiumService.GetPremiumsPorPolizas(nbranch, nproduct, npolicy);

                result = Ok(premiums);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, $"Error al obtener premios por póliza: {ex.Message}");

            }

            return result;
        }

        //GET: api/premium/{nreceipt}
        [HttpGet("{nreceipt}")]
        public async Task<ActionResult<int?>> GetNumeroDeRecibo(int nreceipt)
        {
            ActionResult<int?> result;

            try
            {
                var numeroRecibo = await premiumService.GetNumeroDeRecibo(nreceipt);

                result = numeroRecibo == null
                    ? NotFound($"No se encontró el recibo con número {nreceipt}.")
                    : Ok(new { NumeroRecibo = numeroRecibo });
            }
            catch (Exception ex)
            {
                result = StatusCode(500, $"Error al obtener el número de recibo: {ex.Message}");
            }

            return result;

        }


        //GET: api/premium
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Premium>>> GetPremiums()
        {
            try
            {
                var premiums = await premiumService.GetAll();

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
                var premiums = await premiumService.GetPremiumsPorEnvioACobro(nway_pay);


                return Ok(premiums);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar recibos por envio a cobro: {ex.Message}");
            }
        }

        [HttpPatch("anular")]
        public async Task<IActionResult> AnularReciboAsync(int nreceipt, int nnullcode)
        {
            ActionResult result;
            try
            {
                await premiumService.AnularReciboAsync(nreceipt, nnullcode);
                result = Ok(new { message = "Recibo anulado exitosamente." });
            }
            catch (Exception ex)
            {
                result = StatusCode(500, $"Error al anular el recibo: {ex.Message}");
            }

            return result;
        }

        [HttpPatch("pago-devolucion/{nwaypay}")]
        public async Task<IActionResult> PagoDevolucion(int nwaypay)
        {
            ActionResult result;
            try
            {
                await premiumService.PagoDevolucion(nwaypay);
                result = Ok(new { message = "Pago de devolución procesado exitosamente." });
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException?.Message;
                return StatusCode(500, $"Error al procesar el pago de devolución: {ex.Message} - Inner: {inner}");
            }
            return result;
        }
    }
}


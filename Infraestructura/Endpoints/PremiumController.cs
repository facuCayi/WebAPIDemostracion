using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Dominio.Contracts.Servicios;

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
        [HttpGet("premium/{nbranch}/{nproduct}/{npolicy}")]
        public async Task<ActionResult<IEnumerable<Premium>>> GetPremiumsPorPolizas(int nbranch, int nproduct, int npolicy)
        {
            ActionResult result;
            try
            {
                var premiums = await premiumService.GetPremiumsPorPolizas(nbranch, nproduct, npolicy);

                result = Ok(premiums);
            }
            catch (Exception ex)
            {
                result =  StatusCode(500, $"Error al obtener premios por póliza: {ex.Message}");

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


    }
}

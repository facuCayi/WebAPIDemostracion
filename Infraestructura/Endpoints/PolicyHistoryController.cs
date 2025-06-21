using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Dominio.Contracts.Servicios;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyHistoryController : ControllerBase
    {
        private readonly IPolicyHistoryService policyHistoryService;

        public PolicyHistoryController(IPolicyHistoryService policyHistoryService)
        {
            this.policyHistoryService = policyHistoryService;
        }

        //GET: api/PolicyHistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PolicyHistory>>> GetPolicyHistorys()
        {
            ActionResult result;
            try
            {
                var historiales = await policyHistoryService.GetAll();

                result =  Ok(historiales);

            }
            catch (Exception ex)
            {
                result = StatusCode(500, $"Error al listar historiales de poliza: {ex.Message}");
            }

            return result;
        }
    }
}

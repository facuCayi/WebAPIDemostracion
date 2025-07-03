using Dominio.Contracts.Servicios;
using Dominio.DTO_s.Response;
using Dominio.Models;
using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

        // GET: api/policyHistory/{Nbranch}/{Nproduct}/{Npolicy}
        [HttpGet("{nbranch}/{nproduct}/{npolicy}")]
        public async Task<ActionResult<IEnumerable<HistorialPolizaResponse>>> GetPolicyHistorys(int nbranch, int nproduct, int npolicy)
        {
            ActionResult<IEnumerable<HistorialPolizaResponse>> result;
            try
            {
                List<HistorialPolizaResponse> historiales = await policyHistoryService.GetHistorialPoliza(nbranch,nproduct,npolicy);

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

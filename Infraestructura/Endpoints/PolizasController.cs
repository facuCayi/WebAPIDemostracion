using Dominio.Contracts.Servicios;
using Dominio.Models;
using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dominio.DTO_s.Response;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolizasController : ControllerBase
    {
        private readonly IPolizaService polizaService;
        public PolizasController(IPolizaService polizaService)
        {
            this.polizaService = polizaService;
        }

        // GET: api/poliza/{Nbranch}/{Nproduct}/{Npolicy}
        [HttpGet("poliza/{Nbranch}/{Nproduct}/{Npolicy}")]
        public ActionResult<PolizaBuscarResponse> GetPoliza(int Nbranch, int Nproduct, int Npolicy)
        {
            ActionResult<PolizaBuscarResponse> result;
            try
            {
                PolizaBuscarResponse polizas = polizaService.GetPoliza(Nbranch, Nproduct, Npolicy);

                result =  Ok(polizas);
            }
            catch (Exception ex)
            {
                result =  StatusCode(500, $"Error al obtener pólizas: {ex.Message}");
            }

            return result;
        }

        // GET: api/polizas/cliente/{sclient}
        [HttpGet("cliente/{sclient}")]
        public ActionResult<IEnumerable<PolizaPorClienteResponse>> GetPolizasPorCliente(string sclient)
        {
            ActionResult<IEnumerable<PolizaPorClienteResponse>> result;
            try
            {
                List<PolizaPorClienteResponse> polizas = polizaService.GetPolizasByUserCode(sclient);

                result = Ok(polizas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al filtrar polizas por cliente: {ex.Message}");
            }

            return result;
        }

    }
}

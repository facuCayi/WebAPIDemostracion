using Dominio.Contracts.Servicios;
using Dominio.Models;
using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dominio.DTO_s.Response;
using Dominio.DTO_s.Request;

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

                result = Ok(polizas);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, $"Error al obtener pólizas: {ex.Message}");
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

        [HttpPost("insertar")]
        public async Task<IActionResult> InsertarPoliza([FromBody] NewPolicyRequest polizaRequest, [FromQuery] string idTitular, [FromQuery] string idAsegurado, [FromQuery] string idBeneficiarios)
        {
            ActionResult result;
            try
            {
                int nuevaPolizaId = await polizaService.InsertarNuevaPoliza(polizaRequest, idTitular, idAsegurado, idBeneficiarios);
                result = Ok(new { message = "Póliza insertada exitosamente", id = nuevaPolizaId });
            }
            catch (Exception ex)
            {
                result = StatusCode(500, new { message = "Error interno al insertar póliza", error = ex.ToString() });
            }

            return result;
        }

        [HttpPatch("anular")]
        public async Task<IActionResult> AnularPoliza([FromBody] AnularPolizaRequest polizaRequest,  int motAnulacion,  DateTime fechaAnulacion)
        {
            ActionResult result;
            try
            {
                bool anulado = await polizaService.AnularPolicy(polizaRequest, motAnulacion, fechaAnulacion);
                result = Ok(new { message = "Póliza anulada exitosamente", anulado });
            }
            catch (Exception ex)
            {
                result = StatusCode(500, new { message = "Error al anular póliza", error = ex.ToString() });
            }
            return result;

        }

        [HttpPost("endosar")]
        public async Task<IActionResult> EndosarPoliza([FromBody] EndosoRequest endosoRequest)
        {
            ActionResult result;
            try
            {
                bool endosado = await polizaService.EndosarPolicy(endosoRequest);
                result = Ok(new { message = "Póliza endosada exitosamente", endosado });
            }
            catch (Exception ex)
            {
                result = StatusCode(500, new { message = "Error al endosar póliza", error = ex.ToString() });
            }
            return result;
        }
    }
}

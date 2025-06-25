using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Dominio.Contracts.Servicios;
using Dominio.DTO_s.Response;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class SexoController : ControllerBase
    {
        private readonly ISexoService sexoService;

        public SexoController(ISexoService sexoService)
        {
            this.sexoService = sexoService;
        }

        //GET: api/Sexo
        [HttpGet]
        public ActionResult<IEnumerable<SexoDDLResponse>> GetSexos()
        {
            ActionResult<IEnumerable<SexoDDLResponse>> result;
            try
            {
                List<SexoDDLResponse> sexos = sexoService.GetAll();   

                result = Ok(sexos);

            }
            catch (Exception ex)
            {
                result = StatusCode(500, $"Error al lista sexos: {ex.Message}");
            }

            return result;
        }
    }
}

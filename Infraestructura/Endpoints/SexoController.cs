using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Dominio.Contracts.Servicios;

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
        public async Task<ActionResult<IEnumerable<Sexo>>> GetSexos()
        {
            ActionResult result;
            try
            {
                var sexos = await sexoService.GetAll();   

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

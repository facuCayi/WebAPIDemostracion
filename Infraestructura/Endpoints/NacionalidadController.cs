using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class NacionalidadController : ControllerBase
    {
        private readonly INacionalidadService nacionalidadService;
        public NacionalidadController(INacionalidadService nacionalidadService)
        {
            this.nacionalidadService = nacionalidadService;
        }

        //GET: api/Nacionalidad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nacionalidad>>> GetNacionalidades()
        {
            ActionResult result;
            try
            {
                var nacionalidades = await nacionalidadService.GetAll();

                result =  Ok(nacionalidades);

            }
            catch (Exception ex)
            {
                result =  StatusCode(500, $"Error al listar nacionalidades: {ex.Message}");
            }

            return result;
        }
    }
}

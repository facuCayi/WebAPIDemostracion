using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.DTO_s.Response;

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
        public ActionResult<IEnumerable<ClaseDDLResponse>> GetNacionalidades()
        {
            ActionResult<IEnumerable<ClaseDDLResponse>> result;
            try
            {
                List<ClaseDDLResponse> nacionalidades =  nacionalidadService.GetAll();

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

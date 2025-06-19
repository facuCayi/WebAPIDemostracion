using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Dominio.Contracts.Servicios;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tab_LocatController : ControllerBase
    {
        private readonly ITab_LocatService tab_locatService;
        public Tab_LocatController(ITab_LocatService tab_locatService)
        {
            this.tab_locatService = tab_locatService;
        }

        //GET: api/Tab_locat

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tab_locat>>> GetTab_locats()
        {
            ActionResult result;
            try
            {
                var localidades = await tab_locatService.GetAll();
                result =  Ok(localidades);

            }
            catch (Exception ex)
            {
                result = StatusCode(500, $"Error al obtener localidades: {ex.Message}");
            }

            return result;
        }
    }
}

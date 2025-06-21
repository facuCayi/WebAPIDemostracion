using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Dominio.Contracts.Servicios;


namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipalityController : Controller
    {
        private readonly IMunicipalityService municipalityService;

        public MunicipalityController(IMunicipalityService municipalityService)
        {
           this.municipalityService = municipalityService;
        }

        // GET: api/municipality
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Municipality>>> GetMunicipalities()
        {
            ActionResult result;
            try
            {
                var municipalities = await municipalityService.GetAll();
                result =  Ok(municipalities);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, $"Error al obtener municipalidades: {ex.Message}");
            }

            return result;
        }

        // GET: api/municipality/province/{nprovince}
        [HttpGet("{nprovince}")]
        public async Task<ActionResult<IEnumerable<Municipality>>> GetMunicipalityPorNProvince(int nprovince)
        {
            ActionResult result;
            try
            {
                var municipalidad = await municipalityService.GetByProvince(nprovince);

                result =  Ok(municipalidad);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, $"Error al obtener municipalidades: {ex.Message}");
            }

            return result;
        }
    }
}

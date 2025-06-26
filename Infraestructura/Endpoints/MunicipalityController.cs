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
    public class MunicipalityController : Controller
    {
        private readonly IMunicipalityService municipalityService;

        public MunicipalityController(IMunicipalityService municipalityService)
        {
           this.municipalityService = municipalityService;
        }

        // GET: api/municipality
        [HttpGet]
        public ActionResult<IEnumerable<ClaseDDLResponse>> GetMunicipalities()
        {
            ActionResult<IEnumerable<ClaseDDLResponse>> result;
            try
            {
                List<ClaseDDLResponse> municipalities =  municipalityService.GetAll();
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
        public ActionResult<IEnumerable<ClaseDDLResponse>> GetMunicipalityPorNProvince(int nprovince)
        {
            ActionResult<IEnumerable<ClaseDDLResponse>> result;
            try
            {
                List<ClaseDDLResponse> municipalidad = municipalityService.GetByProvince(nprovince);

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

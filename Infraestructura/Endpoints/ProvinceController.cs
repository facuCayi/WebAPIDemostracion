using Dominio.Contracts.Servicios;
using Dominio.DTO_s.Response;
using Dominio.Models;
using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceService provinceService;

        public ProvinceController(IProvinceService provinceService)
        {
           this.provinceService = provinceService;
        }

        //GET: api/province
        [HttpGet]
        public ActionResult<IEnumerable<ClaseDDLResponse>> GetProvinces()
        {
            ActionResult<IEnumerable<ClaseDDLResponse>> result;
            try
            {
                List<ClaseDDLResponse> provinces = provinceService.GetAll();
                return Ok(provinces);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, $"Error al obtener provincias: {ex.Message}");
            }

            return result;
        }


    }
}

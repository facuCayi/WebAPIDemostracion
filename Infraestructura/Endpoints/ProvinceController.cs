using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Dominio.Contracts.Servicios;

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
        public async Task<ActionResult<IEnumerable<Province>>> GetProvinces()
        {
            ActionResult result;
            try
            {
                var provinces = await provinceService.GetAll();
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

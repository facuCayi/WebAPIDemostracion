using Dominio.Contracts.Servicios;
using Dominio.DTO_s.Response;
using Dominio.Models;
using Microsoft.AspNetCore.Mvc;


namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductmasterController : ControllerBase
    {
        private readonly IProductmasterService productmasterService;

        public ProductmasterController(IProductmasterService productmasterService)
        {
          this.productmasterService = productmasterService;
        }

        //GET: api/productmaster/{nbranch}
        [HttpGet("{nbranch}")]
        public ActionResult<IEnumerable<ClaseDDLResponse>> GetProductosPorRama(int nbranch)
        {
            ActionResult<IEnumerable<ClaseDDLResponse>> result;
            try
            {
                List<ClaseDDLResponse> productos = productmasterService.GetProductosPorRama(nbranch);  

                result =  Ok(productos);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, $"Error al obtener los productos por rama: {ex.Message}");
            }

            return result;
        }

        //GET: api/productmaster
        [HttpGet]
        public ActionResult<IEnumerable<ClaseDDLResponse>> GetProductos()
        {
            ActionResult result;
            try
            {
                List<ClaseDDLResponse> productos = productmasterService.GetAll();

                result =  Ok(productos);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, $"Error al listar los productos : {ex.Message}");
            }

            return result;
        }

    }
}

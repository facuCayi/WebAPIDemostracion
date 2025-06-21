using Dominio.Contracts.Servicios;
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
        public async Task<ActionResult<IEnumerable<Productmaster>>> GetProductosPorRama(int nbranch)
        {
            ActionResult result;
            try
            {
                var productos = await productmasterService.GetProductosPorRama(nbranch);  

                result =  Ok(productos);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, $"Error al obtener los productos por rama: {ex.Message}");
            }

            return result;
        }

        //GET: api/productmaster}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productmaster>>> GetProductos()
        {
            ActionResult result;
            try
            {
                var productos = await productmasterService.GetAll();

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

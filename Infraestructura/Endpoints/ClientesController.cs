using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Dominio.Contracts.Servicios;

namespace Infraestructura.Endpoints
{

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
        private readonly IClienteService clienteService;

        public ClientesController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        // GET: api/clientes/{sclient}
        [HttpGet("{sclient}")]
        public async Task<ActionResult<Client>> GetClientePorSclient(string sclient)
        {
            ActionResult result;

            try
            {
                var cliente = await clienteService.GetClientePorSclient(sclient);

                result =  Ok(cliente);
            }
            catch (Exception ex)
            {
                result =  StatusCode(500, $"Error al obtener cliente: {ex.Message}");
            }

            return result;
        }
    }
}
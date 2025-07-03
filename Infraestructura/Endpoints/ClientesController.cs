using Aplicacion.Services;
using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.DTO_s.Request;
using Dominio.DTO_s.Response;
using Dominio.Models;
using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult<ClienteFindResponse> GetClientePorSclient(string sclient)
        {
            ActionResult<ClienteFindResponse> result;

            try
            {
                ClienteFindResponse cliente = clienteService.GetClientePorSclient(sclient);

                result =  Ok(cliente);
            }
            catch (Exception ex)
            {
                result =  StatusCode(500, $"Error al obtener cliente: {ex.Message}");
            }

            return result;
        }

        [HttpPost("new")]
        public ActionResult<bool> CreateClient([FromBody] NewClientJuridicoRequest request)
        {
            ActionResult result;
            try
            {
                clienteService.CreateJuridicClient(request);

                result = Ok(true); // Retorna true si la creación fue exitosa
            }
            catch (Exception ex)
            {
                result = StatusCode(500, ex.Message); // Manejo de errores
            }
            return result;
        }


        

        [HttpPatch("cambiar-estado/{clienteId}")]
        public IActionResult CambiarEstadoCliente(string clienteId)
        {
            try
            {
                     clienteService.CambiarEstadoCliente(clienteId);
                return NoContent(); // 204

            }
                catch (Exception ex)
            {
                return StatusCode(500, $"Error al cambiar el estado del cliente: {ex.Message}");
            }
        }

        [HttpPatch("cambiar-estado-async/{clienteId}")]
        public async Task<IActionResult> CambiarEstadoClienteAsync(string clienteId)
        {
            if (string.IsNullOrWhiteSpace(clienteId))
            {
                return BadRequest("El ID del cliente no puede ser nulo o vacío.");
            }

            try
            {
                await clienteService.CambiarEstadoClienteAsync(clienteId);
                return NoContent(); // 204
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al cambiar el estado del cliente: {ex.Message}");
            }
        }

        [HttpPut("editar")]
        public async Task<IActionResult> EditarCliente([FromBody] NewClientRequest clienteRequest)
        {
            if (clienteRequest == null || string.IsNullOrWhiteSpace(clienteRequest.CodigoCliente))
                return BadRequest("Datos de cliente inválidos");

            var clienteEntidad = new Client
            {
                Sclient = clienteRequest.CodigoCliente,
                Dbirthdat = clienteRequest.FechaNacimiento,
                Sfirstname = clienteRequest.Nombre,
                Slastname = clienteRequest.Apellido,
                Slastname2 = clienteRequest.SegundoApellido,
                Slegalname = clienteRequest.Cuit,
                Ssexclien = clienteRequest.Sexo,
                Nnationality = clienteRequest.Nacionalidad
            };
            try
            {
                await clienteService.EditarClienteAsync(clienteEntidad);
                return NoContent(); // 204
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al editar el cliente: {ex.Message}");
            }
        }

        [HttpGet("buscar-clientes-por-rol")]
        public async Task<ResulClientesPorRolResponse> BuscarClientesPorRol([FromQuery] int Rama, [FromQuery] int Producto, [FromQuery] int NPoliza)
        {
           
            return  await clienteService.GetClientesPorRolAsync(Rama, Producto, NPoliza);
        }

    }
}
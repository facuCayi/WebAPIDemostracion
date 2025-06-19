using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Dominio.Contracts.Servicios;

    
namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUsuarioService usuarioService;
        public UsersController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        //GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsuarios()
        {

            ActionResult result;
            try
            {
                var usuarios = await usuarioService.GetAll();
                result = Ok(usuarios);
            }
            catch (Exception ex)
            {
                result = StatusCode(500, $"Error al listar usuarios: {ex.Message}");
            }
           
             return result;

        }


        //GET: api/users/{nusercode}
        [HttpGet("/nusercode")]
        public async Task<ActionResult<Users>> GetUsers(int nusercode)
        {
            ActionResult result;
            try
            { 
                var usuario = await usuarioService.GetUsuarioByUserCode(nusercode);
                result =  Ok(usuario);
            }
            catch (Exception ex)
            {
                result =  StatusCode(500, $"Error al buscar usuario: {ex.Message}");
            }

            return result;

        }
    }
}

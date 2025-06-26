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
    public class UsersController : ControllerBase
    {

        private readonly IUsuarioService usuarioService;
        public UsersController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        //GET: api/Users
        [HttpGet]
        public  ActionResult<IEnumerable<ClaseDDLResponse>> GetUsuarios()
        {

            ActionResult<IEnumerable<ClaseDDLResponse>> result;
            try
            {
                List<ClaseDDLResponse> usuarios = usuarioService.GetAll();
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
        public ActionResult<ClaseDDLResponse> GetUsers(int nusercode)
        {
            ActionResult<ClaseDDLResponse> result;
            try
            {
                ClaseDDLResponse usuario = usuarioService.GetUsuarioByUserCode(nusercode);
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

using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly AppDbContext _context;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        //GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsuarios()
        {
            try
            {
                var usuarios = await _context.Users.ToListAsync();

                return Ok(usuarios);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al listar usuarios: {ex.Message}");
            }
        }


        //GET: api/users/{nusercode}
        [HttpGet("/nusercode")]
        public async Task<ActionResult<Users>> GetUsers(int nusercode)
        {
            try
            {
                var usuario = await _context.Users
                    .Where( u =>
                        u.Nusercode == nusercode
                        ).FirstOrDefaultAsync();

                return Ok(usuario);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar usuario: {ex.Message}");

            }


        }
    }
}

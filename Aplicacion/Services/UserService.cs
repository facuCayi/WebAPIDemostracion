using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.Models;

namespace Aplicacion.Services;

    public class UserService : IUsuarioService
{

    private readonly IUsuarioRepository usuarioRepository;
    public UserService(IUsuarioRepository usuarioRepository)
    {
        this.usuarioRepository = usuarioRepository;
    }


    public Task<List<Users>> GetAll()
    {
        return usuarioRepository.GetAllUsuarios();
    }

    public Task<Users> GetUsuarioByUserCode(int nusercode)
    {
        return usuarioRepository.GetByUserCode(nusercode);
    }
}


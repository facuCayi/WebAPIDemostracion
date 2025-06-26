using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.DTO_s.Response;
using Dominio.Models;

namespace Aplicacion.Services;

    public class UserService : IUsuarioService
{

    private readonly IUsuarioRepository usuarioRepository;
    public UserService(IUsuarioRepository usuarioRepository)
    {
        this.usuarioRepository = usuarioRepository;
    }


    public List<ClaseDDLResponse> GetAll()
    {
        List<Users> clientes = usuarioRepository.GetAll().Result;
        List<ClaseDDLResponse> clientesResponse = clientes.Select(c => new ClaseDDLResponse
        {
            NCODIGO = c.Nusercode,
            SDESCRIPT = c.Sinitials == null ? string.Empty : c.Sinitials.Trim()
        }).ToList();

        return clientesResponse;
    }

    public ClaseDDLResponse GetUsuarioByUserCode(int nusercode)
    {
        Users usuario =  usuarioRepository.GetByUserCode(nusercode).Result;
        ClaseDDLResponse usuarioResponse = new ClaseDDLResponse
        {
            NCODIGO = usuario.Nusercode,
            SDESCRIPT = usuario.Sinitials == null ? string.Empty : usuario.Sinitials.Trim()
        };

        return usuarioResponse;
    }
}


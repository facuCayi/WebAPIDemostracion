using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface IUsuarioService
    {
        Task<List<Users>> GetAll();

        Task<Users> GetUsuarioByUserCode(int nusercode);

    }
}

using Dominio.Models;

namespace Dominio.Contracts.Repositorios;

    public interface IUsuarioRepository
{
    Task<Users> GetByUserCode(int nusercode);

    Task<List<Users>> GetAll();


}


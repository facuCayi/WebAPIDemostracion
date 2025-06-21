using Dominio.Models;

namespace Dominio.Contracts.Repositorios
{
    public interface IProvinceRepository
    {
        Task<List<Province>> GetAll();
    }
}

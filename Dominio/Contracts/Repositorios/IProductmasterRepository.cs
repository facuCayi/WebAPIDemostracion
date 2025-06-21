using Dominio.Models;
namespace Dominio.Contracts.Repositorios
{
    public interface IProductmasterRepository
    {
        Task<List<Productmaster>> GetProductosPorRama(int nbranch);

        Task<List<Productmaster>> GetAll();
    }
}

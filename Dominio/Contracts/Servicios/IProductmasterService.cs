using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface IProductmasterService
    {
        Task<List<Productmaster>> GetAll();

        Task<List<Productmaster>> GetProductosPorRama(int nbranch);
    }
}

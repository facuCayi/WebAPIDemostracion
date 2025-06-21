using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.Models;


namespace Aplicacion.Services
{
    public class ProductmasterService : IProductmasterService
    {
        private readonly IProductmasterRepository _productmasterRepository;
        public ProductmasterService(IProductmasterRepository productmasterRepository)
        {
            _productmasterRepository = productmasterRepository;
        }
        public Task<List<Productmaster>> GetAll()
        {
            return _productmasterRepository.GetAll();
        }

        public Task<List<Productmaster>> GetProductosPorRama(int nbranch)
        {
            return _productmasterRepository.GetProductosPorRama(nbranch);
        }
    }
    
}

using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.DTO_s.Response;
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
        public List<ClaseDDLResponse> GetAll()
        {
            List<Productmaster> products = _productmasterRepository.GetAll().Result;
            List<ClaseDDLResponse> response = products.Select(p => new ClaseDDLResponse
            {
                NCODIGO = p.Nproduct,
                SDESCRIPT = p.Sdescript == null ? string.Empty : p.Sdescript.Trim()
            }).ToList();

            return response;
            }
        public List<ClaseDDLResponse> GetProductosPorRama(int nbranch)
        {
            List<Productmaster> products = _productmasterRepository.GetProductosPorRama(nbranch).Result;
            List<ClaseDDLResponse> response = products
                .Select(p => new ClaseDDLResponse
            {
                NCODIGO = p.Nproduct,
                SDESCRIPT = p.Sdescript == null ? string.Empty : p.Sdescript.Trim()
            }).ToList();

            return response;
        }
    }
    
}

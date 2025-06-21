using Dominio.Contracts.Repositorios;
using Dominio.Models;
using Dominio.Contracts.Servicios;

namespace Aplicacion.Services
{
    public class PolicyHistoryService : IPolicyHistoryService
    {
        private readonly IPolicyHistoryRepository _policyHistoryRepository;
        public PolicyHistoryService(IPolicyHistoryRepository policyHistoryRepository)
        {
            _policyHistoryRepository = policyHistoryRepository;
        }
        public  Task<List<PolicyHistory>> GetAll()
        {
            return  _policyHistoryRepository.GetAll();
        }
    }
    
}

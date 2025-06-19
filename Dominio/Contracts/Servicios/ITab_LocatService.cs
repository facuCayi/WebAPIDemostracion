
using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface ITab_LocatService
    {
        Task<List<Tab_locat>> GetAll();
    }
    
}

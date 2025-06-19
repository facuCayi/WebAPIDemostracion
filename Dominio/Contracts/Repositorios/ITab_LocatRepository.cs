using Dominio.Models;

namespace Dominio.Contracts.Repositorios
{
    public interface ITab_LocatRepository
    {
        Task<List<Tab_locat>> GetAll();
    }
}

using Dominio.Models;

namespace Dominio.Contracts.Repositorios
{
    public interface IClientesRepository
    {
        Task<Client> GetClientePorSclient(string sclient);
    }
}

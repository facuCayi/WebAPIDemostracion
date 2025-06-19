using Dominio.Models;


namespace Dominio.Contracts.Repositorios
{
    public interface IPolizaRepository
    {
        Task<List<Poliza>> GetAll();
        Task<List<Poliza>> GetPolizasByUserCode(string sclient);
    }
}

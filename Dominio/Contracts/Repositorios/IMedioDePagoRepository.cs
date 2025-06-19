using Dominio.Models;


namespace Dominio.Contracts.Repositorios
{
    public interface IMedioDePagoRepository
    {
        Task<List<MedioDePago>> GetAll();
    }
}

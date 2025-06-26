using Dominio.Models;


namespace Dominio.Contracts.Repositorios
{
    public interface IPolizaRepository
    {
        Task<Poliza> GetPoliza(int Nbranch, int Nproduct, int Npolicy);
        Task<List<Poliza>> GetPolizasByUserCode(string sclient);
    }
}

using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface IPolizaService
    {

        Task<List<Poliza>> GetAll();

        Task<List<Poliza>> GetPolizasByUserCode(string sclient);
    }
}

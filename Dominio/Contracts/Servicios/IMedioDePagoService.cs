using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface IMedioDePagoService
    {
        Task<List<MedioDePago>> GetAll();   
    }
}

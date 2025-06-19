using Dominio.Models;

namespace Dominio.Contracts.Repositorios
{
    public interface IMotAnulPolRepository
    {
        Task<List<MotAnulacionPoliza>> GetAll();
    }
}

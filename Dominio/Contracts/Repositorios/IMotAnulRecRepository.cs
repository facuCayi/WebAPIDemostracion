using Dominio.Models;

namespace Dominio.Contracts.Repositorios
{
    public interface IMotAnulRecRepository
    {
        Task<List<MotAnulacionRecibo>> GetAll();
    }
}

using Dominio.Models;

namespace Dominio.Contracts.Repositorios
{
    public interface INacionalidadRepository
    {
        Task<List<Nacionalidad>> GetAll();
    }
}

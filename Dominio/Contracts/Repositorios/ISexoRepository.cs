using Dominio.Models;

namespace Dominio.Contracts.Repositorios
{
    public interface ISexoRepository
    {
         Task<List<Sexo>> GetAll();
        
    }
}

using Dominio.Models;

namespace Dominio.Contracts.Repositorios
{
    public interface ISexoRepository
    {
         public Task<List<Sexo>> GetAll();
        
    }
}

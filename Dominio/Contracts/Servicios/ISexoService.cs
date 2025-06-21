using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface ISexoService
    {
        public Task<List<Sexo>> GetAll();
    }
}

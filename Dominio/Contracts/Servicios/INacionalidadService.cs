using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface INacionalidadService
    {
        Task<List<Nacionalidad>> GetAll();
       
    }
}

using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface IMotAnulPolService
    {

       Task<List<MotAnulacionPoliza>> GetAll();
    }
}

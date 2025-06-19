using Dominio.Models;
using System.Threading.Tasks;

namespace Dominio.Contracts.Servicios
{
    public interface IMotAnulRecService
    {

        Task<List<MotAnulacionRecibo>> GetAll();
    }
}

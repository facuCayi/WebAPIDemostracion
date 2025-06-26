using Dominio.DTO_s.Response;
using Dominio.Models;
using System.Threading.Tasks;

namespace Dominio.Contracts.Servicios
{
    public interface IMotAnulRecService
    {

        List<ClaseDDLResponse> GetAll();
    }
}

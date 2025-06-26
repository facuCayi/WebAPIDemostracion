using Dominio.DTO_s.Response;
using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface IUsuarioService
    {
        List<ClaseDDLResponse> GetAll();

        ClaseDDLResponse GetUsuarioByUserCode(int nusercode);

    }
}

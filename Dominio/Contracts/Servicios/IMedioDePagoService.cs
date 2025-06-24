using Dominio.DTO_s.Response;
using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface IMedioDePagoService
    {
        List<MedioDePagoComboBoxTratPolResponse> GetAll();
        List<MedioDePagoTabalMantResponse> GetAllMant();
    }
}

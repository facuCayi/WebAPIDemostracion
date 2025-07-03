using Dominio.DTO_s.Response;
using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface IPolicyHistoryService
    {
          Task<List<HistorialPolizaResponse>> GetHistorialPoliza(int nbranch, int nproduct, int npolicy);
    }
}

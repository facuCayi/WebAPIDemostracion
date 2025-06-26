using Dominio.DTO_s.Response;
using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface IPolizaService
    {

        PolizaBuscarResponse GetPoliza(int Nbranch, int Nproduct, int Npolicy);

        List<PolizaPorClienteResponse> GetPolizasByUserCode(string sclient);
    }
}

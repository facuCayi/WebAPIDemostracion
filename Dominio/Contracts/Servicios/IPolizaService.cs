using Dominio.DTO_s.Request;
using Dominio.DTO_s.Response;
using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface IPolizaService
    {

        PolizaBuscarResponse GetPoliza(int Nbranch, int Nproduct, int Npolicy);

        List<PolizaPorClienteResponse> GetPolizasByUserCode(string sclient);

        Task<int> InsertarNuevaPoliza(NewPolicyRequest poliza, string IdTitular, string IdAsegurado, string IdBeneficiarios);

        Task<bool> AnularPolicy(AnularPolizaRequest poliza, int motAnulacion, DateTime fechaAnulacion);

    }
}

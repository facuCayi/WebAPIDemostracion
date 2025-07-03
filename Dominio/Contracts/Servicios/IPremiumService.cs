using Dominio.DTO_s.Response;
using Dominio.Models;

namespace Dominio.Contracts.Servicios
{
    public interface IPremiumService
    {
        List<ReciboResponse> GetPremiumsPorPolizas(int nbranch, int nproduct, int npolicy);
        Task<List<Premium>> GetAll();
        Task<List<Premium>> GetPremiumsPorEnvioACobro(int nway_pay);

        Task<int?> GetNumeroDeRecibo(int nreceipt);

        Task AnularReciboAsync(int nreceipt, int nnullcode);

        Task PagoDevolucion(int nwaypay);
    }
}

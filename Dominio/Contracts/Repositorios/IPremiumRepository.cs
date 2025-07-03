using Dominio.Models;

namespace Dominio.Contracts.Repositorios
{
    public interface IPremiumRepository
    {
        //Task<List<(Premium Premium, string Ramo, string Producto, string MetodoPago, string Estado, string EstadoCobro, string MotivoAnulacion, string Usuario)>> GetRecibosPorPoliza(int nbranch, int nproduct, int npolicy);
        Task<List<Premium>> GetRecibosPorPoliza(int nbranch, int nproduct, int npolicy);

        Task<int?> GetNumeroDeRecibo(int nreceipt);

        Task<List<Premium>> GetAll();
        Task<List<Premium>> GetPremiumsPorEnvioACobro(int nway_pay);
        Task AnularReciboAsync(int nreceipt, int nnullcode);
        Task PagoDevolucion(int nwaypay);
    }
}

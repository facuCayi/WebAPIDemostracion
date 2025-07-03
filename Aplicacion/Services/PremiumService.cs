using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.Models;
using Dominio.DTO_s.Response;

namespace Aplicacion.Services
{
    public class PremiumService : IPremiumService
    {
        private readonly IPremiumRepository _premiumRepository;
        public PremiumService(IPremiumRepository premiumRepository)
        {
            _premiumRepository = premiumRepository;
        }

        public Task<List<Premium>> GetAll()
        {
            return _premiumRepository.GetAll();
        }

        public Task<int?> GetNumeroDeRecibo(int nreceipt)
        {
            return _premiumRepository.GetNumeroDeRecibo(nreceipt);
        }

        public Task<List<Premium>> GetPremiumsPorEnvioACobro(int nway_pay)
        {
            return _premiumRepository.GetPremiumsPorEnvioACobro(nway_pay);
        }

        public List<ReciboResponse> GetPremiumsPorPolizas(int nbranch, int nproduct, int npolicy)
        {

            List<Premium> premiums = _premiumRepository.GetRecibosPorPoliza(nbranch, nproduct, npolicy).Result;
            List<ReciboResponse> response = premiums.Select(r => new ReciboResponse
            {
                Ramo = r.Branch?.Sdescript ?? string.Empty,
                Producto = r.Product?.Sdescript ?? string.Empty,
                Npolicy = r.Npolicy,
                Nreceipt = r.Nreceipt,
                FechaInicio = r.Deffecdate,
                FechaEmision = r.Dissuedat,
                FechaFin = r.Dexpirdat,
                MetodoPago = r.Way_pay?.Sdescript ?? string.Empty,
                NPremium = r.Npremium,
                Nbalance = r.Nbalance,
                Estado = r.Estado?.Sdescript ?? string.Empty,
                EstadoCobro = r.EstadoCobro?.Sdescript ?? string.Empty,
                FechaAnulacion = r.Dnulldate,
                MotivoAnulacion = r.NullCode?.Sdescript ?? string.Empty,
                UsuarioModificador = r.Usuario?.Sinitials ?? string.Empty
            }).ToList();
            return response;
        }

        public async Task AnularReciboAsync(int nreceipt, int nnullcode)
        {
            await _premiumRepository.AnularReciboAsync(nreceipt, nnullcode);

        }

        public async Task PagoDevolucion(int nwaypay)
        {
            await _premiumRepository.PagoDevolucion(nwaypay);
        }
    }
}

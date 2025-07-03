using Dominio.Contracts.Repositorios;
using Dominio.Models;
using Dominio.Contracts.Servicios;
using Dominio.DTO_s.Response;


namespace Aplicacion.Services
{
    public class PolicyHistoryService : IPolicyHistoryService
    {
        private readonly IPolicyHistoryRepository _policyHistoryRepository;
        public PolicyHistoryService(IPolicyHistoryRepository policyHistoryRepository)
        {
            _policyHistoryRepository = policyHistoryRepository;
        }
        public async Task <List<HistorialPolizaResponse>> GetHistorialPoliza(int nbranch, int nproduct, int npolicy)
        {
            var (historial, rama, producto) = await _policyHistoryRepository
                .GetHistorialPolizaCompleto(nbranch, nproduct, npolicy);

            return historial.Select(ph => new HistorialPolizaResponse
            {
                Rama = rama,
                Producto = producto,
                Npolicy = ph.Npolicy,
                Nmovment = ph.Nmovment,
                Sclient = ph.Sclient,
                FechaEmision = ph.Ddate_origi,
                FechaInicio = ph.Dstartdate,
                FechaFin = ph.Dexpirdat,
                Ncapital = ph.Ncapital,
                MetodoPago = ph.Way_pay?.Sdescript,
                FechaAnulacion = ph.Dcomdate,
                DnullDate = ph.Dnulldate,
                MotivoAnulacion = ph.Nnullcode,
                UltimoUsuario = ph.Usuario?.Sinitials
            }).ToList();
        }

    }
}

using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.Models;
using Dominio.DTO_s.Response;

namespace Aplicacion.Services
{
    public class PolizaService : IPolizaService
    {

        private readonly IPolizaRepository polizaRepository;
        public PolizaService(IPolizaRepository polizaRepository)
        {
            this.polizaRepository = polizaRepository;
        }

        public PolizaBuscarResponse GetPoliza(int Nbranch, int Nproduct, int Npolicy)
        {
            Poliza poliza = polizaRepository.GetPoliza(Nbranch, Nproduct, Npolicy).Result;
            PolizaBuscarResponse polizaResponse = new PolizaBuscarResponse
            {
                NBRANCH = poliza.Nbranch,
                NPRODUCT = poliza.Nproduct,
                NPOLICY = poliza.Npolicy,
                SCLIENT = poliza.Sclient,
               DDATE_ORIGI = poliza.Ddate_origi,
               DSTARTDATE = poliza.Dstartdate,
               DEXPIRDAT =  poliza.Dexpirdat,
               NCAPITAL = poliza.Ncapital,
               DCOMPDATE = poliza.Dcomdate,
               DNULLDATE = poliza.Dnulldate,
               NNULLCODE = poliza.Nnullcode,
               NUSERCODE = poliza.Nusercode,
               NWAY_PAY = poliza.Nway_pay,

            };
            return polizaResponse;
        }

        public List<PolizaPorClienteResponse> GetPolizasByUserCode(string sclient)
        {
            List<Poliza> polizas = polizaRepository.GetPolizasByUserCode(sclient).Result;
            List<PolizaPorClienteResponse> polizasResponse = polizas.Select(p => new PolizaPorClienteResponse
            {
                Poliza = p.Npolicy,
                Rama = p.Nbranch,
                Producto = p.Product.Nproduct,
            }).ToList();
            
            return polizasResponse;
        }

     
    }
}

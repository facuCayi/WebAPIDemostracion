using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.DTO_s.Request;
using Dominio.DTO_s.Response;
using Dominio.Models;

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


        public async Task<int> InsertarNuevaPoliza(NewPolicyRequest polizaRequest, string IdTitular, string IdAsegurado, string IdBeneficiarios)
        {
            Poliza poliza = new Poliza
            {
                Nbranch = polizaRequest.Ramo,
                Nproduct = polizaRequest.Producto,
                Sclient = polizaRequest.ClienteId,
                Ddate_origi = polizaRequest.FechaInicio,
                Nway_pay = polizaRequest.FormaPago,
                Ncapital = polizaRequest.Capital,
                Dexpirdat = polizaRequest.FechaInicio.AddYears(1)

            };

            return await polizaRepository.InsertarNuevaPoliza(poliza, IdTitular, IdAsegurado, IdBeneficiarios);
        }

        public Task<bool> AnularPolicy(AnularPolizaRequest polizaRequest, int motivoAnul, DateTime fechaAnul)
        {
            return polizaRepository.AnularPolicy(polizaRequest, motivoAnul, fechaAnul);
        }


    }
}

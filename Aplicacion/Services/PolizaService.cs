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

        public Task<bool> EndosarPolicy(EndosoRequest endosoRequest)
        {
            Poliza poliza = new Poliza
            {
                Nbranch = endosoRequest.Poliza.Nbranch,
                Nproduct = endosoRequest.Poliza.Nproduct,
                Npolicy = endosoRequest.Poliza.Npolicy,
                Nway_pay = endosoRequest.Poliza.Nway_pay,
            };

            int indiceEndoso = endosoRequest.IndiceTipoEndoso;
            DateTime fechaEndoso = endosoRequest.FechaEndoso;
            string beneficiarios = endosoRequest.Beneficiarios;
            Address direccionPostal = new Address
            {
                Nrecowner = endosoRequest.DireccionPostal.Nrecowner == 0 ? 0 : endosoRequest.DireccionPostal.Nrecowner,
                Skeyaddress = endosoRequest.DireccionPostal.Skeyaddress,
                Deffecdate = endosoRequest.DireccionPostal.Deffecdate,
                Sinfor = endosoRequest.DireccionPostal.Sinfor,
                Sstreet = endosoRequest.DireccionPostal.Sstreet,
                Nheight = endosoRequest.DireccionPostal.Nheight == 0 ? 0 : endosoRequest.DireccionPostal.Nheight,
                Sbuild = endosoRequest.DireccionPostal.Sbuild,
                Nfloor = endosoRequest.DireccionPostal.Nfloor == 0 ? null : endosoRequest.DireccionPostal.Nfloor,
                Sdepartment = endosoRequest.DireccionPostal.Sdepartment,
                SzipCode = endosoRequest.DireccionPostal.SzipCode,
                Szone = endosoRequest.DireccionPostal.Szone,
                Nlocal = endosoRequest.DireccionPostal.Nlocal == 0 ? 0 : endosoRequest.DireccionPostal.Nlocal,
                Nmunicipality = endosoRequest.DireccionPostal.Nmunicipality == 0 ? 0 : endosoRequest.DireccionPostal.Nmunicipality,
                Nprovince = endosoRequest.DireccionPostal.Nprovince == 0 ? 0 : endosoRequest.DireccionPostal.Nprovince,
                SeMail = endosoRequest.DireccionPostal.SeMail

            };

            return polizaRepository.EndosarPolicy(indiceEndoso, fechaEndoso, poliza,beneficiarios, direccionPostal);
        }

    }
}

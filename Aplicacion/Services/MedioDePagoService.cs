using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.DTO_s.Response;
using Dominio.Models;

namespace Aplicacion.Services
{
    public class MedioDePagoService : IMedioDePagoService
    {
        private readonly IMedioDePagoRepository    medioDePagoRepository;

               public MedioDePagoService(IMedioDePagoRepository medioDePagoRepository)
        {
            this.medioDePagoRepository = medioDePagoRepository;
        }

        public List<MedioDePagoComboBoxTratPolResponse> GetAll()
        {
            // Assuming WayPayComboBoxResponse is a DTO that maps to WayPay entity
            List<MedioDePago> wayPays = medioDePagoRepository.GetAll().Result;
            List<MedioDePagoComboBoxTratPolResponse> response = wayPays.Select(wp => new MedioDePagoComboBoxTratPolResponse
            {
                NWAY_PAY = wp.Nway_pay,
                SDESCRIPT = wp.Sdescript == null ? string.Empty : wp.Sdescript.Trim()
            }).ToList();
            return response;
        }

        public List<MedioDePagoTabalMantResponse> GetAllMant()
        {
            // Assuming WayPayTablaMantResponse is a DTO that maps to WayPay entity
            List<MedioDePago> wayPays = medioDePagoRepository.GetAll().Result;
            List<MedioDePagoTabalMantResponse> response = wayPays.Select(wp => new MedioDePagoTabalMantResponse
            {
                NWay_Pay = wp.Nway_pay,
                SDescript = wp.Sdescript == null ? string.Empty : wp.Sdescript.Trim(),
                DCompDate = wp.Dcomdate,
                NStatRegt = wp.Nstatregt,
                SUserCode = wp.Usuario.Sinitials == null ? string.Empty : wp.Usuario.Sinitials.Trim()
            }).ToList();
            return response;
        }
       
    }
}

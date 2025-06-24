using Infraestructura.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Dominio.Contracts.Servicios;
using Dominio.DTO_s.Response;
using Aplicacion.Services;

namespace Infraestructura.Endpoints
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedioDePagoController : ControllerBase
    {
        private readonly IMedioDePagoService medioDePagoService;

        public MedioDePagoController(IMedioDePagoService medioDePagoService)
        {
            this.medioDePagoService = medioDePagoService;
        }

        //GET: api/MedioDePago
        [HttpGet]
        public ActionResult<IEnumerable<MedioDePagoComboBoxTratPolResponse>> GetMediosDePago()
        {
            ActionResult<IEnumerable<MedioDePagoComboBoxTratPolResponse>> resultado;
            try
            {
                List<MedioDePagoComboBoxTratPolResponse> wayPay = medioDePagoService.GetAll();
                resultado = Ok(wayPay);
            }
            catch (Exception ex)
            {
                resultado = StatusCode(500, ex.Message);
            }
            return resultado;
        }
    }
}

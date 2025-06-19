using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.Models;

namespace Aplicacion.Services
{
    public class MedioDePagoService : IMedioDePagoService
    {
        private readonly IMedioDePagoRepository medioDePagoRepository;

               public MedioDePagoService(IMedioDePagoRepository medioDePagoRepository)
        {
            this.medioDePagoRepository = medioDePagoRepository;
        }
   

        public Task<List<MedioDePago>> GetAll()
        {
            return medioDePagoRepository.GetAll();
        }
    }
}

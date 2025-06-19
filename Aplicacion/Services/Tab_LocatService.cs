using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.Models;

namespace Aplicacion.Services
{
    public class Tab_LocatService : ITab_LocatService
    {

        private readonly ITab_LocatRepository tab_locatRepository;

        public Tab_LocatService(ITab_LocatRepository tab_locatRepository)
        {
            this.tab_locatRepository = tab_locatRepository;
        }


        public Task<List<Tab_locat>> GetAll()
        {
            return tab_locatRepository.GetAll();
        }
    }
}

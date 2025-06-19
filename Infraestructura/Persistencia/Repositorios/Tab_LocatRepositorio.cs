using Dominio.Contracts.Repositorios;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Persistencia.Repositorios
{
    public class Tab_LocatRepositorio : ITab_LocatRepository
    {
        private readonly AppDbContext context;
        public Tab_LocatRepositorio(AppDbContext context)
        {
            this.context = context;
        }
        public  Task<List<Tab_locat>> GetAll()
        {
            return context.Tab_Locats.ToListAsync();
        }
    }
    
}

using Dominio.Contracts.Repositorios;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Persistencia.Repositorios
{
    public class ProvinceRepositorio : IProvinceRepository
    {
        private readonly AppDbContext context;
        public ProvinceRepositorio(AppDbContext context)
        {
            this.context = context;
        }
        public Task<List<Province>> GetAll()
        {
            return context.Provinces
                .Include(c => c.Usuario)
                .ToListAsync();
        }
    }
    
}

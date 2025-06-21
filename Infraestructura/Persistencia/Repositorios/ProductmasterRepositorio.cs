using Dominio.Contracts.Repositorios;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Persistencia.Repositorios
{
    public class ProductmasterRepositorio : IProductmasterRepository
    {
        private readonly AppDbContext context;

        public ProductmasterRepositorio(AppDbContext context)
        {
            this.context = context;
        }
        public Task<List<Productmaster>> GetAll()
        {
            return context.Productmasters.ToListAsync();
        }

        public Task<List<Productmaster>> GetProductosPorRama(int nbranch)
        {
            return context.Productmasters
                .Where(p => p.Nbranch == nbranch)
                .ToListAsync();
        }
    }
}

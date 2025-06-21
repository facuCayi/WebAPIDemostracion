using Dominio.Contracts.Repositorios;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Persistencia.Repositorios
{
    public class PolicyHistoryRepositorio : IPolicyHistoryRepository
    {
        private readonly AppDbContext context;
        public PolicyHistoryRepositorio(AppDbContext context)
        {
            this.context = context;
        }
        public Task<List<PolicyHistory>> GetAll()
        {
            return context.PolicyHistories
                .Include(p => p.Client)
                .Include(p => p.Way_pay)
                .Include(p => p.NullCode)
                .Include(p => p.Usuario)
                .Include(p => p.Branch)
                .Include(p => p.Product)
                .ToListAsync();
        }
    }
}

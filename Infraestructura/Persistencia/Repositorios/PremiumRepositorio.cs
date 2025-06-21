using Dominio.Contracts.Repositorios;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Persistencia.Repositorios
{
    public class PremiumRepositorio : IPremiumRepository
    {
        private readonly AppDbContext context;
        public PremiumRepositorio(AppDbContext context)
        {
            this.context = context;
        }
        public Task<List<Premium>> GetAll()
        {
            return context.Premiums.ToListAsync();
        }

        public Task<List<Premium>> GetPremiumsPorEnvioACobro(int nway_pay)
        {
            return context.Premiums
                    .Where(p =>
                    p.Nway_pay == nway_pay
                    )
                    .ToListAsync();
        }

        public Task<List<Premium>> GetPremiumsPorPolizas(int nbranch, int nproduct, int npolicy)
        {
            return context.Premiums
                     .Where(p =>
                     p.Nbranch == nbranch &&
                     p.Nproduct == nproduct &&
                     p.Npolicy == npolicy
                     )
                     .ToListAsync();
        }
    }
}

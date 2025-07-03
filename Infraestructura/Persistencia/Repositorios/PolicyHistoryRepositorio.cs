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

        public async Task<(List<PolicyHistory> historial, string rama, string producto)> GetHistorialPolizaCompleto(int nbranch, int nproduct, int npolicy)
        {
            var historial = await context.PolicyHistories
                .Where(ph => ph.Nbranch == nbranch &&
                             ph.Nproduct == nproduct &&
                             ph.Npolicy == npolicy)
                .Include(ph => ph.Way_pay)
                .Include(ph => ph.NullCode)
                .Include(ph => ph.Usuario)
                .ToListAsync();

            var rama = await context.RamoComercials
                .Where(b => b.Nbranch == nbranch)
                .Select(b => b.Sdescript)
                .FirstOrDefaultAsync();

            var producto = await context.Productmasters
                .Where(p => p.Nbranch == 1 && p.Nproduct == nproduct)
                .Select(p => p.Sdescript)
                .FirstOrDefaultAsync();

            return (historial, rama, producto);
        }
    }
}

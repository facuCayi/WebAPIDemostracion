using Dominio.Contracts.Repositorios;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Persistencia.Repositorios
{
    public class PolizaRepositorio : IPolizaRepository
    {
        private readonly AppDbContext context;

        public PolizaRepositorio(AppDbContext context)
        {
            this.context = context;
        }

        public Task<Poliza> GetPoliza(int Nbranch, int Nproduct, int Npolicy)
        {
            return  context.Polizas
            .Include(p => p.Client)
            .Include(p => p.Way_pay)
            .Include(p => p.NullCode)
            .Include(p => p.Usuario)
            .Include(p => p.Product)
            .Where(p => p.Nbranch == Nbranch &&
                    p.Nproduct == Nproduct && 
                    p.Npolicy == Npolicy)
           .FirstOrDefaultAsync();
        }

        public Task<List<Poliza>> GetPolizasByUserCode(string sclient)
        {
            return context.Polizas
           .Include(p => p.Client)
           .Include(p => p.Way_pay)
           .Include(p => p.NullCode)
           .Include(p => p.Usuario)
           .Include(p => p.Product)
           .Where(p => p.Sclient == sclient)
           .ToListAsync();
        }
    }
}

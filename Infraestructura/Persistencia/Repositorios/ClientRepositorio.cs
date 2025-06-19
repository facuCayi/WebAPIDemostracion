using Dominio.Contracts.Repositorios;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Persistencia.Repositorios
{
    public class ClientRepositorio : IClientesRepository
    {
        private readonly AppDbContext context;

        public ClientRepositorio(AppDbContext context)
        {
            this.context = context;
        }

        public Task<Client> GetClientePorSclient(string sclient)
        {
            return context.Clients
                .Include(c => c.Sex)
                .Include(c => c.Nacionality)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(c => c.Sclient == sclient);
        }
    }
}

using Dominio.Contracts.Repositorios;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Persistencia.Repositorios
{
    public class NacionalidadRepositorio : INacionalidadRepository
    {
        private readonly AppDbContext context;

        public NacionalidadRepositorio(AppDbContext context)
        {
           this.context = context;
        }

        public Task<List<Nacionalidad>> GetAll()
        {
            return context.Nacionalidades.ToListAsync();
        }
    }
}

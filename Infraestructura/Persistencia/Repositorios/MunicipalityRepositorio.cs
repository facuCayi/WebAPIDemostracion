using Dominio.Contracts.Repositorios;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;


namespace Infraestructura.Persistencia.Repositorios
{
    public class MunicipalityRepositorio : IMunicipalityRepository
    {
        private readonly AppDbContext context;
        public MunicipalityRepositorio(AppDbContext context)
        {
            this.context = context;
        }
        public Task<List<Municipality>> GetAll()
        {
            return context.Municipalities.ToListAsync();
        }
        public Task<List<Municipality>> GetByProvince(int nprovince)
        {
            return context.Municipalities
                .Where(m => m.Nprovince == nprovince)
                .ToListAsync();
        }
    }
   
}

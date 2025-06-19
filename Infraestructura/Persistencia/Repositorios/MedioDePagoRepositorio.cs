using Dominio.Contracts.Repositorios;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Persistencia.Repositorios
{
    public class MedioDePagoRepositorio : IMedioDePagoRepository
    {
        private readonly AppDbContext context;
        public MedioDePagoRepositorio(AppDbContext context)
        {
            this.context = context;
        }
        public Task<List<MedioDePago>> GetAll()
        {
            return context.MediosDePago.ToListAsync();
               
        }

    }
    
}

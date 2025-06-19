using Dominio.Contracts.Repositorios;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;


namespace Infraestructura.Persistencia.Repositorios
{
    public class MotAnulRecRepositorio : IMotAnulRecRepository
    {
        private readonly AppDbContext context;
        public MotAnulRecRepositorio(AppDbContext context)
        {
            this.context = context;
        }

        public Task<List<MotAnulacionRecibo>> GetAll()
        {
            return context.MotAnulacionRecibos.ToListAsync();
        }

       
    }
}

using Dominio.Contracts.Repositorios;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Persistencia.Repositorios
{
    public class MotAnulPolRepositorio : IMotAnulPolRepository
    {
        private readonly AppDbContext context;
        public MotAnulPolRepositorio(AppDbContext context)
        {
            this.context = context;
        }
        public Task<List<MotAnulacionPoliza>> GetAll()
        {
            return context.MotAnulacionPolizas.ToListAsync();

        }

    }
    
}

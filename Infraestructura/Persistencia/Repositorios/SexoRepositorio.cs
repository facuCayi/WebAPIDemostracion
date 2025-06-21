using Dominio.Contracts.Repositorios;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;


namespace Infraestructura.Persistencia.Repositorios
{
    public class SexoRepositorio : ISexoRepository
    {
        private readonly AppDbContext _context;
        public SexoRepositorio(AppDbContext context)
        {
            _context = context;
        }
        public Task<List<Sexo>> GetAll()
        {
            return _context.Sexos.ToListAsync();
        }
    }

}

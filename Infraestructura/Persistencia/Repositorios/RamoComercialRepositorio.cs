using Dominio.Contracts.Repositorios;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Persistencia.Repositorios
{
    public class RamoComercialRepositorio : IRamoComercialRepository
    {
        private readonly AppDbContext _context;
        public RamoComercialRepositorio(AppDbContext context)
        {
            _context = context;
        }
        public  Task<List<RamoComercial>> GetAll()
        {
            return _context.RamoComercials.ToListAsync();
        }
    }
}

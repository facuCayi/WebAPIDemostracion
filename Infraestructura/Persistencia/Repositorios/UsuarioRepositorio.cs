using Dominio.Contracts.Repositorios;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Persistencia.Repositorios;

 public class UsuarioRepositorio : IUsuarioRepository
{
    private readonly AppDbContext context;

    public UsuarioRepositorio(AppDbContext context)
    {
        this.context = context;
    }

    public Task<List<Users>> GetAll()
    {
        return context.Users.ToListAsync();
    }

    public Task<Users> GetByUserCode(int nusercode)
    {
        return context.Users
            .Where(u => u.Nusercode == nusercode)
            .FirstOrDefaultAsync();
    }
}


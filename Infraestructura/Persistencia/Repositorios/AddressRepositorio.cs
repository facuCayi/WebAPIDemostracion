using Dominio.Contracts.Repositorios;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Persistencia.Repositorios
{
    public class AddressRepositorio : IAddressRepository
    {
        private readonly AppDbContext context;

        public AddressRepositorio(AppDbContext context)
        {
            this.context = context;
        }
        public Task<Address?> GetAddress(int nrecowner, string skeyaddress, string deffecdate, string sinfor)
        {
            if (!DateTime.TryParseExact(deffecdate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var fecha))
            {
                throw new ArgumentException("Formato de fecha inválido. Se espera yyyy-MM-dd", nameof(deffecdate));
            }

            var fechaSiguiente = fecha.AddDays(1);

            return context.Addresses
                .Include(a => a.Municipio)
                .Include(a => a.Provincia)
                .Where(a =>
                    a.Nrecowner == nrecowner &&
                    a.Skeyaddress.Trim() == skeyaddress.Trim() &&
                    a.Sinfor.Trim() == sinfor.Trim() &&
                    a.Deffecdate >= fecha &&
                    a.Deffecdate < fechaSiguiente)
                .FirstOrDefaultAsync();
        }
    }
}

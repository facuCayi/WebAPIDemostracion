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
            DateTime fecha;
            DateTime.TryParseExact(deffecdate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out fecha);

            return context.Addresses
                .Where(a =>
                    a.Nrecowner == nrecowner &&
                    a.Skeyaddress.Trim() == skeyaddress.Trim() &&
                    a.Sinfor.Trim() == sinfor.Trim() &&
                    a.Deffecdate.Date == fecha.Date)
                .FirstOrDefaultAsync();
        }
    }
}

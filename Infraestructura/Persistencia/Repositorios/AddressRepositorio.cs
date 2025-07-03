using Dominio.Contracts.Repositorios;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

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

        public Task<bool> CreateAddress(Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address), "Address cannot be null");
            }
            try
            {
                context.Database.OpenConnection();
                OracleCommand command = new OracleCommand("SP_INSERT_ADDRESS", context.Database.GetDbConnection() as OracleConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_NRECOWNER", OracleDbType.Int32, address.Nrecowner, ParameterDirection.Input);
                command.Parameters.Add("P_SKEYADDRESS", OracleDbType.Varchar2, address.Skeyaddress, ParameterDirection.Input);
                command.Parameters.Add("P_DEFFECDATE", OracleDbType.Date, address.Deffecdate, ParameterDirection.Input);
                command.Parameters.Add("P_SINFOR", OracleDbType.Varchar2, address.Sinfor, ParameterDirection.Input);
                command.Parameters.Add("P_SSTREET", OracleDbType.Varchar2, address.Sstreet, ParameterDirection.Input);
                command.Parameters.Add("P_NHEIGHT", OracleDbType.Int32, address.Nheight, ParameterDirection.Input);
                command.Parameters.Add("P_SBUILD", OracleDbType.Varchar2, address.Sbuild, ParameterDirection.Input);
                command.Parameters.Add("P_NFLOOR", OracleDbType.Int32, address.Nfloor, ParameterDirection.Input);
                command.Parameters.Add("P_SDEPARTMENT", OracleDbType.Varchar2, address.Sdepartment, ParameterDirection.Input);
                command.Parameters.Add("P_SZIP_CODE", OracleDbType.Varchar2, address.SzipCode, ParameterDirection.Input);
                command.Parameters.Add("P_SZONE", OracleDbType.Varchar2, address.Szone, ParameterDirection.Input);
                command.Parameters.Add("P_NLOCAL", OracleDbType.Int32, address.Nlocal, ParameterDirection.Input);
                command.Parameters.Add("P_NMUNICIPALITY", OracleDbType.Int32, address.Nmunicipality, ParameterDirection.Input);
                command.Parameters.Add("P_NPROVINCE", OracleDbType.Int32, address.Nprovince, ParameterDirection.Input);
                command.Parameters.Add("P_SE_MAIL", OracleDbType.Varchar2, address.SeMail, ParameterDirection.Input);
                command.Parameters.Add("P_NBRANCH", OracleDbType.Int32, address.Nbranch, ParameterDirection.Input);
                command.Parameters.Add("P_NPRODUCT", OracleDbType.Int32, address.Nproduct, ParameterDirection.Input);
                command.Parameters.Add("P_NPOLICY", OracleDbType.Int32, address.Npolicy, ParameterDirection.Input);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la dirección", ex);
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }
    }
}

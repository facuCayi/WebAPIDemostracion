using Dominio.Contracts.Repositorios;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Infraestructura.Persistencia.Repositorios
{
    public class PremiumRepositorio : IPremiumRepository
    {
        private readonly AppDbContext context;
        public PremiumRepositorio(AppDbContext context)
        {
            this.context = context;
        }
        public Task<List<Premium>> GetAll()
        {
            return context.Premiums.ToListAsync();
        }

        public Task<List<Premium>> GetPremiumsPorEnvioACobro(int nway_pay)
        {
            return context.Premiums
                    .Where(p =>
                    p.Nway_pay == nway_pay
                    )
                    .ToListAsync();
        }

        public Task<int?> GetNumeroDeRecibo(int nreceipt)
        {
           return context.Premiums
                .Where(p => p.Nreceipt == nreceipt)
                .Select(p => (int?) p.Nreceipt)
                .FirstOrDefaultAsync();
        }

        //public async Task<List<(Premium Premium, string Ramo, string Producto, string MetodoPago, string Estado, string EstadoCobro, string MotivoAnulacion, string Usuario)>> GetRecibosPorPoliza(int nbranch, int nproduct, int npolicy)
        public  Task<List<Premium>> GetRecibosPorPoliza(int nbranch, int nproduct, int npolicy)

        {
            return context.Premiums
             .Include(p => p.Branch).
        Include(p => p.Product).
        Include(p => p.Way_pay).
        Include(p => p.Estado).
        Include(p => p.EstadoCobro).
        Include(p => p.NullCode).
        Include(p => p.Usuario).
        Where(p => p.Nbranch == nbranch && p.Nproduct == nproduct && p.Npolicy == npolicy).ToListAsync();

        }

        public async Task AnularReciboAsync(int nreceipt, int nnullcode)
        {
            var random = new Random();
            var recibo = await context.Premiums.FirstOrDefaultAsync(p => p.Nreceipt == nreceipt);
            if (recibo == null)
            {
                throw new KeyNotFoundException($"No se encontró un recibo con NRECEIPT = {nreceipt}");
            }
            recibo.Nstatus_pre = 3; // 3 es el estado de anulado
            recibo.Nnullcode = nnullcode;
            recibo.Dnulldate = DateTime.Now;
            recibo.Nstatus_pay = null;
            recibo.Nusercode = random.Next(1, 3);
            await context.SaveChangesAsync();
        }

        public async Task PagoDevolucion(int nwaypay)
        {
         
            var random = new Random();
            var recibos = await context.Premiums.Where(p => p.Nway_pay == nwaypay && p.Nstatus_pay == 1).ToListAsync();
            if (recibos.Count == 0)
            {
                throw new KeyNotFoundException($"No se encontraron recibos con NWAY_PAY = {nwaypay}");
            }
            foreach (var recibo in recibos)
            {
                recibo.Nstatus_pre = random.Next(1, 3); 
                recibo.Nstatus_pay = random.Next(2, 4); 
                recibo.Dissuedat = DateTime.Now;
            }
            await context.SaveChangesAsync();
        }

        public async Task EnvioACobro(string listaRecibos, int mediopPago)
        {

            try
            {
                context.Database.OpenConnection();
                OracleCommand command = new OracleCommand("SP_FIND_CLIENTS_BY_ROL", context.Database.GetDbConnection() as OracleConnection);
                command.CommandText = "SP_ENVIAR_A_COBRO_2";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add("P_NWAY_PAY", OracleDbType.Int32).Value = mediopPago;
                command.Parameters.Add("P_SLISTA_RECIBOS", OracleDbType.Char, listaRecibos, ParameterDirection.Input);
                await command.ExecuteNonQueryAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al enviar a cobro", ex);
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }
    }
}

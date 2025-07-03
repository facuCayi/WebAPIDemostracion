using Dominio.Contracts.Repositorios;
using Dominio.DTO_s.Request;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infraestructura.Persistencia.Repositorios
{
    public class PolizaRepositorio : IPolizaRepository
    {
        private readonly AppDbContext context;

        public PolizaRepositorio(AppDbContext context)
        {
            this.context = context;
        }

        public  Task<bool> AnularPolicy(AnularPolizaRequest polizaRequest, int motAnulacion, DateTime fechaAnulacion)
        {
            try
            {
                context.Database.OpenConnection();
                OracleCommand command = new OracleCommand("SP_ANULAR_POLICY", context.Database.GetDbConnection() as OracleConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_NBRANCH", OracleDbType.Int32, polizaRequest.Ramo, ParameterDirection.Input);
                command.Parameters.Add("P_NPRODUCT", OracleDbType.Int32, polizaRequest.Producto, ParameterDirection.Input);
                command.Parameters.Add("P_NPOLICY", OracleDbType.Int32, polizaRequest.NumeroPoliza, ParameterDirection.Input);
                command.Parameters.Add("P_NNULLCODE", OracleDbType.Int32, motAnulacion, ParameterDirection.Input);
                command.Parameters.Add("P_DNULLDATE", OracleDbType.Date, fechaAnulacion, ParameterDirection.Input);

                command.ExecuteNonQueryAsync();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al anular la póliza", ex);

            }
            finally
            {
                context.Database.CloseConnection();
            }
        }

        public Task<Poliza> GetPoliza(int Nbranch, int Nproduct, int Npolicy)
        {
            return  context.Polizas
            .Include(p => p.Client)
            .Include(p => p.Way_pay)
            .Include(p => p.NullCode)
            .Include(p => p.Usuario)
            .Include(p => p.Product)
            .Where(p => p.Nbranch == Nbranch &&
                    p.Nproduct == Nproduct && 
                    p.Npolicy == Npolicy)
           .FirstOrDefaultAsync();
        }

        public Task<List<Poliza>> GetPolizasByUserCode(string sclient)
        {
            return context.Polizas
           .Include(p => p.Client)
           .Include(p => p.Way_pay)
           .Include(p => p.NullCode)
           .Include(p => p.Usuario)
           .Include(p => p.Product)
           .Where(p => p.Sclient == sclient)
           .ToListAsync();
        }

        public async Task<int> InsertarNuevaPoliza(Poliza poliza, string IdTitular, string IdAsegurado, string IdBeneficiarios)
        {
            int resultado = -1;

            if (poliza == null || 
                 string.IsNullOrWhiteSpace(IdTitular) ||
                 string.IsNullOrWhiteSpace(IdAsegurado) ||
                 string.IsNullOrWhiteSpace(IdBeneficiarios))
            {
                throw new ArgumentException("La póliza no puede ser null y los IDs no pueden estar vacíos o en blanco.");
            }
            try 
            {
                context.Database.OpenConnection();
                OracleCommand command = new OracleCommand("SP_INSERTAR_POLIZA", context.Database.GetDbConnection() as OracleConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_NBRANCH", OracleDbType.Int32, poliza.Nbranch, ParameterDirection.Input);
                command.Parameters.Add("P_NPRODUCT", OracleDbType.Int32, poliza.Nproduct, ParameterDirection.Input);
                command.Parameters.Add("P_SCLIENT", OracleDbType.Char, IdTitular, ParameterDirection.Input);
                command.Parameters.Add("P_DSTARTDATE", OracleDbType.Date, poliza.Dstartdate, ParameterDirection.Input);
                command.Parameters.Add("P_NWAY_PAY", OracleDbType.Int32, poliza.Nway_pay, ParameterDirection.Input);
                command.Parameters.Add("P_NCAPITAL", OracleDbType.Decimal, poliza.Ncapital, ParameterDirection.Input);

                var outputParam = new OracleParameter("P_NPOLICY", OracleDbType.Int32)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputParam);

                command.Parameters.Add("P_ASEGURADO", OracleDbType.Varchar2, ParameterDirection.Input).Value = IdAsegurado;
                command.Parameters.Add("P_DEXPIRDAT", OracleDbType.Date, ParameterDirection.Input).Value = poliza.Dexpirdat;
                command.Parameters.Add("P_BENEFICIARIOS", OracleDbType.Varchar2, ParameterDirection.Input).Value = IdBeneficiarios;

                await command.ExecuteNonQueryAsync();

                resultado = Convert.ToInt32(((OracleDecimal)outputParam.Value).Value);

            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar la nueva póliza", ex);
            }
            finally
            {
                context.Database.CloseConnection();
            }

            return resultado;

        }


    }
}

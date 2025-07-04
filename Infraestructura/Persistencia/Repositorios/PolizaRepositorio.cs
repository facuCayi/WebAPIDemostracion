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

        public async Task<bool> EndosarPolicy(int indiceEndoso, DateTime fechaEndoso, Poliza poliza, string beneficiarios,  Address direccionPostal)
        {
           
            try
            {
                context.Database.OpenConnection();
                OracleCommand command = new OracleCommand("SP_ENDOSAR_POLIZA", context.Database.GetDbConnection() as OracleConnection);
                command.CommandType = CommandType.StoredProcedure;
                //Poliza
                command.Parameters.Add("P_NBRANCH", OracleDbType.Int32).Value = poliza.Nbranch;
                command.Parameters.Add("P_NPRODUCT", OracleDbType.Int32).Value = poliza.Nproduct;
                command.Parameters.Add("P_NPOLICY", OracleDbType.Int32).Value = poliza.Npolicy;

                //Fecha y tipo endoso
                command.Parameters.Add("P_TIPO_ENDOSO", OracleDbType.Int32).Value = indiceEndoso;
                command.Parameters.Add("P_FECHA_ENDOSO", OracleDbType.Date).Value = fechaEndoso;

                // Método de pago
                command.Parameters.Add("P_NWAY_PAY", OracleDbType.Int32).Value = poliza.Nway_pay;

                //String Beneficiarios        
                command.Parameters.Add("P_BENEFICIARIOS", OracleDbType.Char, 4000).Value =beneficiarios;

                // Dirección Postal          
                command.Parameters.Add("P_NRECOWNER", OracleDbType.Int32).Value = direccionPostal.Nrecowner == 0 ? DBNull.Value : (object)direccionPostal.Nrecowner;
                command.Parameters.Add("P_SKEYADDRESS", OracleDbType.Varchar2).Value =direccionPostal.Skeyaddress;
                command.Parameters.Add("P_DEFFECDATE", OracleDbType.Date).Value = direccionPostal.Deffecdate;
                command.Parameters.Add("P_SINFOR", OracleDbType.Varchar2).Value = direccionPostal.Sinfor;
                command.Parameters.Add("P_SSTREET", OracleDbType.Varchar2).Value = direccionPostal.Sstreet;
                command.Parameters.Add("P_NHEIGHT", OracleDbType.Int32).Value = direccionPostal.Nheight == 0 ? DBNull.Value : (object)direccionPostal.Nheight;
                command.Parameters.Add("P_SBUILD", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(direccionPostal.Sbuild) ? DBNull.Value : (object)direccionPostal.Sbuild;
                command.Parameters.Add("P_NFLOOR", OracleDbType.Int32).Value = direccionPostal.Nfloor == 0 ? DBNull.Value : (object)direccionPostal.Nfloor;
                command.Parameters.Add("P_SDEPARTMENT", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(direccionPostal.Sdepartment) ? DBNull.Value : (object)direccionPostal.Sdepartment;
                command.Parameters.Add("P_SZIP_CODE", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(direccionPostal.SzipCode) ? DBNull.Value : (object)direccionPostal.SzipCode;
                command.Parameters.Add("P_SZONE", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(direccionPostal.Szone) ? DBNull.Value : (object)direccionPostal.Szone;
                command.Parameters.Add("P_NLOCAL", OracleDbType.Int32).Value = direccionPostal.Nlocal == 0 ? DBNull.Value : (object)direccionPostal.Nlocal;
                command.Parameters.Add("P_NMUNICIPALITY", OracleDbType.Int32).Value = direccionPostal.Nmunicipality;
                command.Parameters.Add("P_NPROVINCE", OracleDbType.Int32).Value = direccionPostal.Nprovince;
                command.Parameters.Add("P_SE_MAIL", OracleDbType.Varchar2).Value = string.IsNullOrWhiteSpace(direccionPostal.SeMail) ? DBNull.Value : (object)direccionPostal.SeMail;

                await command.ExecuteNonQueryAsync();
              
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al endosar la póliza", ex);
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

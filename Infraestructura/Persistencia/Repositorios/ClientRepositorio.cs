using Dominio.Contracts.Repositorios;
using Dominio.DTO_s.Response;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using System.Drawing;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infraestructura.Persistencia.Repositorios
{
    public class ClientRepositorio : IClientesRepository
    {
        private readonly AppDbContext context;

        public ClientRepositorio(AppDbContext context)
        {
            this.context = context;
        }

        public Task<Client> GetClientePorSclient(string sclient)
        {
            return context.Clients
                .Include(c => c.Sex)
                .Include(c => c.Nacionality)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(c => c.Sclient == sclient);
        }


        public Task<bool> CreateJuridicClient(Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client), "Client cannot be null");
            }
            try
            {
                context.Database.OpenConnection();
                OracleCommand command = new OracleCommand("SP_INSERT_CLIENT", context.Database.GetDbConnection() as OracleConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_SCLIENT", OracleDbType.Char, client.Sclient, ParameterDirection.Input);
                command.Parameters.Add("P_DBIRTHDAT", OracleDbType.Date, client.Dbirthdat, ParameterDirection.Input);
                command.Parameters.Add("P_SFIRSTNAME", OracleDbType.Char, client.Sfirstname, ParameterDirection.Input);
                command.Parameters.Add("P_SLASTNAME", OracleDbType.Char, client.Slastname, ParameterDirection.Input);
                command.Parameters.Add("P_SLASTNAME2", OracleDbType.Char, client.Slastname2, ParameterDirection.Input);
                command.Parameters.Add("P_SCUIT", OracleDbType.Char, client.Scuit, ParameterDirection.Input);
                command.Parameters.Add("P_SLEGALNAME", OracleDbType.Char, client.Slegalname, ParameterDirection.Input);
                command.Parameters.Add("P_SSEXCLIEN", OracleDbType.Char, client.Ssexclien, ParameterDirection.Input);
                command.Parameters.Add("P_NNATIONALITY", OracleDbType.Int32, client.Nnationality, ParameterDirection.Input);
                command.ExecuteNonQuery();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el cliente juridico", ex);
            }
            finally
            {
                context.Database.CloseConnection();
            }



        }

        public Task CreateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public void CambiarEstadoCliente(string clienteId)
        {
            if (string.IsNullOrEmpty(clienteId))
            {
                throw new ArgumentException("El ID del cliente no puede ser nulo o vacío.", nameof(clienteId));
            }

            try
            {
                context.Database.OpenConnection();
                OracleCommand command = new OracleCommand("SP_DISABLE_ENABLE_CLIENT", context.Database.GetDbConnection() as OracleConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_SCLIENT", OracleDbType.Char, clienteId, ParameterDirection.Input);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar el estado del cliente", ex);
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }

        public async Task CambiarEstadoClienteAsync(string clienteId)
        {
            if (string.IsNullOrEmpty(clienteId))
            {
                throw new ArgumentException("El ID del cliente no puede ser nulo o vacío.", nameof(clienteId));
            }

            try
            {
              
                var currentStatus = await context.Clients
                    .Where(c => c.Sclient == clienteId)
                    .Select(c => c.Nstatregt)
                    .FirstOrDefaultAsync();
                
                int newStatus = currentStatus == 0 ? 1 : 0;

                var cliente = await context.Clients.FirstOrDefaultAsync(c => c.Sclient == clienteId);
                if (cliente == null)
                    throw new Exception("Cliente no encontrado");

                cliente.Nstatregt = newStatus;
               // await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar el estado del cliente", ex);
            }
            finally
            {
                await context.SaveChangesAsync();
            }
        }


        public async Task EditarClienteAsync(Client cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente), "El cliente no puede ser nulo");
            }

            try
            {

                var clienteBuscado = await context.Clients.FirstOrDefaultAsync(c => c.Sclient == cliente.Sclient);
                if (clienteBuscado == null)
                    throw new Exception("Cliente no encontrado");

                clienteBuscado.Dbirthdat = cliente.Dbirthdat;
                clienteBuscado.Sfirstname = cliente.Sfirstname;
                clienteBuscado.Slastname = cliente.Slastname;
                clienteBuscado.Slastname2 = cliente.Slastname2;
                clienteBuscado.Scuit = cliente.Scuit;
                clienteBuscado.Slegalname = cliente.Slegalname;
                clienteBuscado.Ssexclien = cliente.Ssexclien;
                clienteBuscado.Nnationality = cliente.Nnationality;
                clienteBuscado.Nstatregt = cliente.Nstatregt;
                clienteBuscado.Dcompdate = DateTime.Now;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el cliente", ex);
            }
            finally
            {
                await context.SaveChangesAsync();

            }
        }

        public async Task<ResulClientesPorRolResponse> BuscarClientesPorRol(int Nbranch, int Nproduct, int Npolicy)
        {
            ResulClientesPorRolResponse response = new ResulClientesPorRolResponse();
            try
            {
                context.Database.OpenConnection();
                OracleCommand command = new OracleCommand("SP_FIND_CLIENTS_BY_ROL", context.Database.GetDbConnection() as OracleConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("P_NBRANCH", OracleDbType.Int32).Value = Nbranch;
                command.Parameters.Add("P_NPRODUCT", OracleDbType.Int32).Value = Nproduct;
                command.Parameters.Add("P_NPOLICY", OracleDbType.Int32).Value = Npolicy;

                command.Parameters.Add("O_TITULAR", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                command.Parameters.Add("O_ASEGURADO", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                command.Parameters.Add("O_BENEFICIARIOS", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                await command.ExecuteNonQueryAsync();

                // TITULAR
                using (var reader = ((OracleRefCursor)command.Parameters["O_TITULAR"].Value).GetDataReader())
                {
                    if (reader.Read())
                    {
                        response.Titular = new ClienteResponse
                        {
                            Sclient = reader["SCLIENT"].ToString(),
                            Scliename = reader["SCLIENAME"].ToString(),
                            Scuit = reader["SCUIT"].ToString()
                        };
                    }
                }

                // ASEGURADO
                using (var reader = ((OracleRefCursor)command.Parameters["O_ASEGURADO"].Value).GetDataReader())
                {
                    if (reader.Read())
                    {
                        response.Asegurado = new ClienteResponse
                        {
                            Sclient = reader["SCLIENT"].ToString(),
                            Scliename = reader["SCLIENAME"].ToString(),
                            Scuit = reader["SCUIT"].ToString()
                        };
                    }
                }

                // BENEFICIARIOS
                using (var reader = ((OracleRefCursor)command.Parameters["O_BENEFICIARIOS"].Value).GetDataReader())
                {
                    while (reader.Read())
                    {
                        response.Beneficiarios.Add(new ClienteResponse
                        {
                            Sclient= reader["SCLIENT"].ToString(),
                            Scliename = reader["SCLIENAME"].ToString(),
                            Scuit = reader["SCUIT"].ToString()
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar clientes por rol", ex);
            }
            finally
            {
                context.Database.CloseConnection();
            }

            return response;
        }
    }
}

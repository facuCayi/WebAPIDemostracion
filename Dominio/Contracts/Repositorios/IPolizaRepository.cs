using Dominio.DTO_s.Request;
using Dominio.Models;


namespace Dominio.Contracts.Repositorios
{
    public interface IPolizaRepository
    {
        Task<Poliza> GetPoliza(int Nbranch, int Nproduct, int Npolicy);
        Task<List<Poliza>> GetPolizasByUserCode(string sclient);

        Task<int> InsertarNuevaPoliza(Poliza poliza, string IdTitular, string IdAsegurado, string IdBeneficiarios);

        Task<bool> AnularPolicy(AnularPolizaRequest poliza, int motAnulacion, DateTime fechaAnulacion);

        Task<bool> EndosarPolicy(int indiceEndoso, DateTime fechaEndoso, Poliza poliza, string beneficiarios, Address direccionPostal);


    }
}

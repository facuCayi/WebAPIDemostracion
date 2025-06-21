using Dominio.Models;
namespace Dominio.Contracts.Servicios
{
    public interface IProvinceService
    {
        Task<List<Province>> GetAll();
    }
}

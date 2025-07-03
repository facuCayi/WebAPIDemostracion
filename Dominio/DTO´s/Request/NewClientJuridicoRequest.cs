
namespace Dominio.DTO_s.Request;

    public class NewClientJuridicoRequest
    {
        public string RazonSocial { get; set; }
        public string RucCUIT { get; set; }
        public DateOnly FechaConstitucion { get; set; }
        public int Nacionalidad { get; set; }
    }


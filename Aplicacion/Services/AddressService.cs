using Dominio.Contracts.Repositorios;
using Dominio.Contracts.Servicios;
using Dominio.DTO_s.Request;
using Dominio.DTO_s.Response;
using Dominio.Models;

namespace Aplicacion.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        public bool CreateAddress(NewAddressRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null");
            }

            Address address = new Address
            {
                Nrecowner = request.PropRegistro,
                Skeyaddress = request.CodigoDireccion,
                Deffecdate = request.FechaEfectiva.ToDateTime(new TimeOnly(0, 0)),
                Sinfor = request.IndicadorInformacion,
                Sstreet = request.Calle,
                Nheight = request.Altura,
                Sbuild = request.Edificio,
                Nfloor = request.Piso,
                Sdepartment = request.Departamento,
                SzipCode = request.CodigoPostal,
                Szone = request.Ciudad,
                Nlocal = request.Localidad,
                Nmunicipality = request.Municipio,
                Nprovince = request.Provincia,
                SeMail = request.CorreoElectronico,
                Nbranch = request.RamoComercial,
                Nproduct = request.Producto,
                Npolicy = request.NumPoliza

            };

            return addressRepository.CreateAddress(address).Result;
        }

        public AddressVisDatosResponse GetAddress(int nrecowner, string skeyaddress, string deffecdate, string sinfor)
        {
            Address direccion = addressRepository.GetAddress(nrecowner, skeyaddress, deffecdate, sinfor).Result;
            AddressVisDatosResponse addressResponse = new AddressVisDatosResponse
            {
                NRECOWNER = direccion.Nrecowner,
                SKEYADDRESS = direccion.Skeyaddress,
                DEFECDATE = direccion.Deffecdate,
                SINFORM = direccion.Sinfor,
                SSTREET = direccion.Sstreet,
                NHEIGHT = direccion.Nheight,
                SBUILD = direccion.Sbuild,
                NFLOOR = direccion.Nfloor,
                SDEPARTMENT = direccion.Sdepartment,
                SZONE = direccion.Szone,
                NLOCAL = direccion.Nlocal,
                NMUNICIPALITY = direccion.Municipio.Nmunicipality,
                NPROVINCE = direccion.Provincia.Nprovince,
                 SE_MAIL = direccion.SeMail,
                 DCOMPDATE = direccion.Dcompdate
            };

            return addressResponse;
        }
    }
    
    
}

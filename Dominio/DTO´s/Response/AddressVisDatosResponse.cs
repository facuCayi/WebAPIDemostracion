

namespace Dominio.DTO_s.Response;

    public class AddressVisDatosResponse
    {
    public int NRECOWNER {  get; set; }
    public string SKEYADDRESS { get; set; } = string.Empty;
    public DateTime DEFECDATE { get; set; }
    public string SINFORM {  get; set; } = string.Empty ;
    public string SSTREET {  get; set; } = string.Empty ;
    public int  NHEIGHT { get; set; }
    public string? SBUILD {  get; set; } = string.Empty ;
    public int? NFLOOR { get; set; }
    public string? SDEPARTMENT { get; set; } = string.Empty;
    public string? SZIP_CODE { get; set; } = string.Empty;
    public string? SZONE { get; set; } = string.Empty;
    public int NLOCAL { get; set; }
    public int NMUNICIPALITY { get; set; }
    public int NPROVINCE { get; set; }
    public string? SE_MAIL { get; set; } = string.Empty;
    public DateTime DCOMPDATE { get; set; }
    public int NUSERCODE { get; set; }

    }




namespace Dominio.DTO_s.Response;

public class ClienteFindResponse
{
    public string SCLIENT { get; set; } = string.Empty;
    public DateTime? DBIRTHDAT { get; set; } 
    public string? SFIRSTNAME { get; set; } = string.Empty;
    public string? SLASTNAME { get; set; } = string.Empty;
    public string? SLASTNAME2 { get; set; } = string.Empty;
    public string? SCUIT { get; set; } = string.Empty;
    public string? SLEGALNAME { get; set; } = string.Empty;
    public string? SCLIENAME { get; set; } = string.Empty;
    public string? SSEXCLIEN { get; set; } = string.Empty;
    public int?  NNATIONALITY { get; set; } 
    public int NSTATREGT { get; set; } 
    public DateTime DCOMPDATE { get; set; } 
    public int? NUSERCODE { get; set; }
}

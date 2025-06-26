using System.Text.Json.Serialization;

namespace Dominio.DTO_s.Response;

public class PolizaPorClienteResponse
{
    [JsonPropertyName("Rama")]
    public int Rama { get; set; } 

    [JsonPropertyName("Producto")]
    public int Producto { get; set; }

    [JsonPropertyName("NumeroPoliza")]
    public int Poliza { get; set; }
}

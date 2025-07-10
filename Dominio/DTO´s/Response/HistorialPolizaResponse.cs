using System.Text.Json.Serialization;

namespace Dominio.DTO_s.Response;

public class HistorialPolizaResponse
{
    [JsonPropertyName("Rama")]
    public string Rama { get; set; }

    [JsonPropertyName("Producto")]
    public string Producto { get; set; }

    [JsonPropertyName("Numero de Poliza")]
    public int Npolicy { get; set; }

    [JsonPropertyName("Numero de movimiento")]
    public int Nmovment { get; set; }

    [JsonPropertyName("Numero de cliente")]
    public string Sclient { get; set; } = string.Empty;

    [JsonPropertyName("Emisión")]
    public DateTime? FechaEmision { get; set; }

    [JsonPropertyName("Inicio de Vigencia")]
    public DateTime? FechaInicio { get; set; }

    [JsonPropertyName("Fin de vigencia")]
    public DateTime? FechaFin { get; set; }

    [JsonPropertyName("Capital")]
    public decimal? Ncapital { get; set; }

    [JsonPropertyName("Metodo de pago")]
    public string MetodoPago { get; set; }

    [JsonPropertyName("Fecha de Anulacion")]
    public DateTime? FechaAnulacion { get; set; }

    [JsonPropertyName("Anulacion")]// Ver si esta repetido con FechaAnulacion   
    public DateTime? DnullDate { get; set; }

    [JsonPropertyName("Motivo de anulación")]
    public int? MotivoAnulacion { get; set; }

    [JsonPropertyName("Ultimo usuario modificador")]
    public string UltimoUsuario { get; set; }
}

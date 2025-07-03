using System.Text.Json.Serialization;

namespace Dominio.DTO_s.Response;

public class ReciboResponse
{

    [JsonPropertyName("Ramo")]
    public string Ramo { get; set; }

    [JsonPropertyName("Producto")]
    public string Producto { get; set; }

    [JsonPropertyName("Numero de Poliza")]
    public int Npolicy { get; set; }

    [JsonPropertyName("Numero de Recibo")]
    public int Nreceipt { get; set; }

    [JsonPropertyName("Emisión")]
    public DateTime? FechaEmision { get; set; }

    [JsonPropertyName("Inicio de Vigencia")]
    public DateTime? FechaInicio { get; set; }

    [JsonPropertyName("Fin de vigencia")]
    public DateTime? FechaFin { get; set; }

    [JsonPropertyName("Metodo de pago")]
    public string MetodoPago { get; set; } = string.Empty;

    [JsonPropertyName("Premio")]
    public int NPremium { get; set; }

    [JsonPropertyName("Saldo de gestion")]
    public int Nbalance { get; set; }

    [JsonPropertyName("Estado")]
    public string Estado { get; set; } = string.Empty;

    [JsonPropertyName("Estado de cobro")]
    public string EstadoCobro { get; set; } = string.Empty;

    [JsonPropertyName("Anulacion")]
    public DateTime? FechaAnulacion { get; set; }

    [JsonPropertyName("Motivo de anulación")]
    public string MotivoAnulacion { get; set; } = string.Empty;

    [JsonPropertyName("Ultimo usuario modificador")]
    public string UsuarioModificador { get; set; } = string.Empty;

}

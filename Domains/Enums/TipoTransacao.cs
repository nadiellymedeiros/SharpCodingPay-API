using System.Text.Json.Serialization;

namespace SharpCodingAPI.Domains.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TipoTransacao {
  SAQUE, 
  DEPOSITO, 
  TRANSFERENCIA,
  VENDA
}
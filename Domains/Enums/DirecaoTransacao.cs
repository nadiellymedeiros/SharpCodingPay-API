using System.Text.Json.Serialization;

namespace SharpCodingAPI.Domains.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DirecaoTransacao {
  ENTRADA,
  SAIDA
}
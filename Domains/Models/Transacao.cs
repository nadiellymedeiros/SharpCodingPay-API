using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SharpCodingAPI.Domains.Enums;

namespace SharpCodingAPI.Domains.Models;

public class Transacoes : Entity
{

[Required]
public decimal Valor { get; set; } 

 public string Historico { get; set; } = null!;

[JsonConverter(typeof(JsonStringEnumConverter))]
public  DirecaoTransacao DirecaoTransacao {get; set;}

[JsonConverter(typeof(JsonStringEnumConverter))]
public  TipoTransacao TipoTransacao {get; set;}

public DateTime? CriadoEm { get; set; } = DateTime.Now;
public string CriadoEmFormatado => CriadoEm?.ToString("dd/MM/yyyy HH:mm:ss") ?? "Data não disponível";

public int UserId {get;set;}

public int NumeroContaDestino { get; set; }

 public int  NumeroContaOrigem {get; set;}

//public User User {get; set;} = null!;



}
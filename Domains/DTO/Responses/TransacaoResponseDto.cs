namespace SharpCodingAPI.Domains.DTO.Responses;

public class TransacaoResponseDto 
{
public decimal Valor { get; set; } 
public string Historico { get; set; } = null!;
public DateTime? CriadoEm { get; set; } = DateTime.Now;
}
using SharpCodingAPI.Domains.Enums;

namespace SharpCodingAPI.Domains.Models;

public class User
{
   public int Id { get; set; }
   public string? Email { get; set; }
   public string? Username { get; set; }
   public string? Password { get; set; }
    public decimal? Saldo { get; set; } 
   public bool IsLogado { get; set; } = false; 

  public List<Transacao>? Transacoes { get; set; }



}
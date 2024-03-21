using System.ComponentModel.DataAnnotations;


namespace SharpCodingAPI.Domains.Models;


  
public class User : Entity
{

   [Required]
   public string? Name { get; set; }

    [Required]
   public string? Email { get; set; }

   [Required]
   public string? Password { get; set; }

  [Required]
   public string? Cpf { get; set; } 

  [Required]
   public string? Telefone { get; set; }
   public decimal? Saldo { get; set; } = 5000.00m;
   public bool IsLogado { get; set; } = false;   

   public bool IsActive {get; set;}= true;

   public DateTime? CriadoEm { get; set; } = DateTime.Now;
   public DateTime? AtualizadoEm { get; set; } = DateTime.Now;
   public DateTime? DeletadoEm { get; set; } = null;          
   public int  NumeroConta {get; set;} 
   private static int proximoNumeroConta = 100000;
   public int Agencia {get; set;} = 202;  
   public List<Transacoes> Transacoes {get; set;} = new();
  

  public User()
        {
            NumeroConta = proximoNumeroConta++;
        }

       
}





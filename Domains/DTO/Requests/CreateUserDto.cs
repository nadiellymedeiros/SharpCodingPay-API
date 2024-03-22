using System.ComponentModel.DataAnnotations;

namespace SharpCodingAPI.Domains.DTO.Requests;
public class CreateUserDto {
 
  [Required]
  [EmailAddress]
  public string Email { get; set; } = null!;
   [Required]
   public string Name { get; set; } = null!;
   [Required]
   public string Password { get; set; } = null!;

    public  string Cpf { get; set; } = null!;

    public  string Telefone { get; set; } = null!;

    public int  NumeroConta {get; set;}
  
    public int Agencia {get; set;} = 202;

     private static int proximoNumeroConta = 100000;

       public CreateUserDto()
        {
            NumeroConta = ++proximoNumeroConta;
        }

}
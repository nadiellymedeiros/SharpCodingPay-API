namespace SharpCodingAPI.Domains.DTO.Requests;
public class CreateUserDto {
    public string Email { get; set; } = null!;
  
   public string Name { get; set; } = null!;

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
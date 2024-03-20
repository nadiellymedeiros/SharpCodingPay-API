namespace SharpCodingAPI.Domains.DTO.Responses;


public class UserResponseDto
{
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;   
    public int  NumeroConta {get; set;}  
    public int Agencia {get; set;} = 202;
}
namespace SharpCodingAPI.Domains.DTO.Responses;

public class LoginResponseDto
{
    public UserResponseDto User { get; set; } = null!;
    public string Token { get; set; } = null!;
}
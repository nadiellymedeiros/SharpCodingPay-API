using System.ComponentModel.DataAnnotations;

namespace SharpCodingAPI.Domains.DTO.Requests;

public class LoginRequestDto
{
    [Required(ErrorMessage = "Você deve informar o e-mail")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Você deve informar uma senha")]
    [MinLength(4, ErrorMessage = "A senha informada deve ter pelo menos 4 caractéres")]
    public string Password { get; set; } = null!;
}
using System.ComponentModel.DataAnnotations;

namespace SharpCodingAPI.Domains.DTO.Requests;
public class TransacaoSaidaDto 
{
[Required(ErrorMessage = "Você deve fornecer o número da conta de destino")]
    public string NumeroContaDestino { get; set; } = null!;

    public int  NumeroContaId {get; set;}


}
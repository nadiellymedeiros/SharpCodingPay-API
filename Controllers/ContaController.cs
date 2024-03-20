using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SharpCodingAPI.Domains.DTO.dbContext;
using SharpCodingAPI.Domains.DTO.Responses;
using SharpCodingAPI.Share;

namespace SharpCodingAPI.Controllers;


[ApiController]
[Route("conta")]

  public class ContaController: ControllerBase{
  private readonly BankDbContext _bankDbContext; 
  private readonly IMapper _mapper;

public ContaController(BankDbContext bankDbContext, IMapper mapper){
    _bankDbContext = bankDbContext;
    _mapper = mapper;
       
}

[HttpGet("{id:int}")]
public ActionResult <ContaResponseDto>GetAccount(int id){

    var contaUser = _bankDbContext.Users.Find(id);

     if (contaUser == null)
        return NotFound();

          

    if(contaUser.IsLogado == true){
    var contaProfile = _mapper.Map<ContaResponseDto>(contaUser);
    return Ok(contaProfile);
    }
    
    

return  NotFound(new MessageResponse($"Usuário não está logado"));


}

}
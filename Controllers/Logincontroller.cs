using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SharpCodingAPI.Domains.DTO.dbContext;
using SharpCodingAPI.Domains.DTO.Requests;
using SharpCodingAPI.Domains.DTO.Responses;
using SharpCodingAPI.Share;

namespace SharpCodingAPI.Controllers;
[ApiController]
[Route("login")]

public class LoginController: ControllerBase{
  private readonly BankDbContext _bankDbContext; 
  private readonly IMapper _mapper;
private readonly IConfiguration _configuration;

  public LoginController(BankDbContext bankDbContext, IMapper mapper, IConfiguration configuration){
    _bankDbContext = bankDbContext;
    _mapper = mapper;
    _configuration = configuration;
    
  }


  [HttpPost] 
    public ActionResult<LoginResponseDto> Authenticate([FromBody] LoginRequestDto userRequisicao){        
              
        var autenticado = _bankDbContext.Users.FirstOrDefault(
          (user) => user.Email == userRequisicao.Email && user.Password == userRequisicao.Password
        );  
       
        if(autenticado == null){
            return Unauthorized(new MessageResponse("E-mail ou senha inválido!"));
        }         

          autenticado.IsLogado = true;

        var result = _bankDbContext.Users.Update(autenticado);
        _bankDbContext.SaveChanges();

        var UserSalvo = result.Entity;

        return Ok(new MessageResponse($"Cliente, {autenticado.Name}, logou com sucesso"));        
    }


    [HttpGet]
    [Route("logout/{id:int}")]

    public IActionResult UpdateIsLogado( ){ 
    {
      // var user = _bankDbContext.Users.Find(id);

      var userLogout = _bankDbContext.Users.FirstOrDefault(
          (user) => user.IsLogado == true
        );       

      if (userLogout == null)
        return NotFound();

      userLogout.IsLogado = false;

     var result = _bankDbContext.Users.Update(userLogout);
      _bankDbContext.SaveChanges();

     var UserSalvo = result.Entity;

     return Ok(UserSalvo);

    // return CreatedAtAction(nameof(GetById), new { UserSalvo.Id }, UserSalvo);
    }
  } 
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharpCodingAPI.Domains.DTO.dbContext;
using SharpCodingAPI.Domains.DTO.Requests;
using SharpCodingAPI.Domains.Models;
using SharpCodingAPI.Share;



namespace SharpCodingAPI.Controllers;


[ApiController]
[Route("users")]

public class UserController : ControllerBase
{

  private readonly BankDbContext _bankDbContext; 

  private readonly IMapper _mapper;


  public UserController(BankDbContext bankDbContext, IMapper mapper){
    _bankDbContext = bankDbContext;
    _mapper = mapper;
  }

[HttpGet]
  public IActionResult GetAll()
{
    var usersWithTransactions = _bankDbContext.Users
        .Include(u => u.Transacoes)
        .ToList();

    return Ok(usersWithTransactions);
}



[HttpGet("{id:int}")]
public IActionResult GetById(int id)
{
    var user = _bankDbContext.Users.Find(id);

    if (user == null)
        return NotFound();

    user.Transacoes = _bankDbContext.Transacoes.Where(t => t.UserId == id).ToList();

    return Ok(user);
}

[HttpPatch("{id:int}/islogado")]
public IActionResult UpdateIsLogado(int id, [FromBody] bool isLogado)
{
    var user = _bankDbContext.Users.Find(id);

    if (user == null)
        return NotFound();
    user.IsLogado = !user.IsLogado;


  var result = _bankDbContext.Users.Update(user);
  _bankDbContext.SaveChanges();

  var UserSalvo = result.Entity;

  return Ok(UserSalvo);

  // return CreatedAtAction(nameof(GetById), new { UserSalvo.Id }, UserSalvo);
}


[HttpPost]
public IActionResult Cadastrar(CreateUserDto novoUser){
  Console.WriteLine(novoUser);

var userParaCadastro = _mapper.Map<User>(novoUser);

var result = _bankDbContext.Users.Add(userParaCadastro);
  _bankDbContext.SaveChanges();
  var UserSalvo = result.Entity;

  return CreatedAtAction(nameof(GetById), new { UserSalvo.Id }, UserSalvo);
 
}

[HttpDelete("delete/{id:int}")]
public ActionResult <MessageResponse> Delete(int id){
  var findUser = _bankDbContext.Users.Find(id);

  if(findUser == null)
    return NotFound();

  _bankDbContext.Remove(findUser);
  _bankDbContext.SaveChanges();

  return Ok(new MessageResponse("Cliente deletado com sucesso"));
}

}
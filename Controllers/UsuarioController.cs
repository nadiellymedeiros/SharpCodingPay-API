using Microsoft.AspNetCore.Mvc;
using SharpCodingAPI.Domains.Enums;
using SharpCodingAPI.Domains.Models;



namespace SharpCodingAPI.Controllers;


[ApiController]
[Route("users")]

public class UserController : ControllerBase
{

 private static List<User> users = new () {
    new () {
      Id = 1,
      Username = "User1",
      Email = "user1@example.com",
      Password = "User1",
      Saldo = 5000.00m,
      IsLogado = false,
      Transacoes = new List<Transacao>
      {
        new Transacao(){
            Valor = 100.00m,
            TipoTransacao = "Deposito",
            DirecaoTransacao ="Entrada"
        }
      }
    },
    new () {
      Id = 2,
      Username = "User2",
      Email = "user2@example.com",
      Password = "User2",
      Saldo = 5000.00m,
      IsLogado = false,
      Transacoes = new List<Transacao>(){
        new Transacao(){
            Valor = 100.00m,
            TipoTransacao = "Saque",
            DirecaoTransacao = "Saida"
        }
      }
    }
  };

  [HttpGet]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]

    [HttpGet]
    public IActionResult GetAll() {

    return Ok(users);
  }
}
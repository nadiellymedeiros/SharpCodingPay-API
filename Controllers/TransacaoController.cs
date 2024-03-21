using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SharpCodingAPI.Domains.DTO.dbContext;
using SharpCodingAPI.Domains.Enums;
using SharpCodingAPI.Domains.Models;
using SharpCodingAPI.Share;

namespace SharpCodingAPI.Controllers;


[ApiController]
[Route("transacoes")]
public class TransacoesController : ControllerBase
{
    private readonly BankDbContext _bankDbContext;
     private readonly IMapper _mapper;

    public TransacoesController(BankDbContext bankDbContext, IMapper mapper) {
        _bankDbContext = bankDbContext;
        _mapper = mapper;
    }

   [HttpGet("{userId:int}")]
    public ActionResult <List<Transacoes>> GetAll(int userId)
    {
        var user = _bankDbContext.Users.First(u => u.Id == userId);

     

        if(user.IsLogado == true){

            var transacoes = _bankDbContext.Transacoes.Where(t => t.UserId == userId ).ToList().OrderByDescending(t => t.CriadoEm);
                if(transacoes == null || !transacoes.Any()){
                return NotFound(new MessageResponse($"Não há transações com o usuário {user.Name}"));
                 }

                 return Ok(transacoes);
  
    
    }
    return  NotFound(new MessageResponse($"Usuário não está logado")); 
      
       
    }

    // [HttpPost]
    // public IActionResult Registrar(Transacoes transacoes){
    //     _bankDbContext.Transacoes.Add(transacoes);
    //     _bankDbContext.SaveChanges();

    //     return Ok("Created!");
    // }

  [HttpPost]
    public ActionResult<MessageResponse> Registrar(Transacoes transacoes){
       var direcaoTransacao = transacoes.DirecaoTransacao;
       var tipoTransacao = transacoes.TipoTransacao;
       var user = _bankDbContext.Users.FirstOrDefault(u => u.Id == transacoes.UserId);
       
       var contaOrigem = _bankDbContext.Users.FirstOrDefault(u => u.NumeroConta == transacoes.NumeroContaOrigem);
        if (contaOrigem == null)
        {
            return NotFound("Conta de origem não encontrada.");
        }

       
        var contaDestino = _bankDbContext.Users.FirstOrDefault(u => u.NumeroConta == transacoes.NumeroContaDestino);
        if (contaDestino == null)
        {
        return NotFound("Conta de destino não encontrada.");
        }

       

        //Transferencia
         if (transacoes.TipoTransacao.Equals(TipoTransacao.TRANSFERENCIA)) {
             
            if(contaDestino == contaOrigem){
            return BadRequest("As contas de origem e destino não podem ser iguais");
            }

            if (user == null)
            {
            return NotFound("Usuário não encontrado.");
            }

            if(user.Saldo < transacoes.Valor){
                return BadRequest("Saldo insulficiente");
            }

            var transacaoContaOrigem = new Transacoes
            {
            
            Historico = $"Transferência enviada para {contaDestino.Name}",
            Valor = transacoes.Valor,
            TipoTransacao = transacoes.TipoTransacao,
            DirecaoTransacao = transacoes.DirecaoTransacao,
            UserId = contaOrigem!.Id,
            NumeroContaDestino = transacoes.NumeroContaDestino,
            NumeroContaOrigem= transacoes.NumeroContaOrigem
            };

            var transacaoContaDestino = new Transacoes
            {
            Historico = $"Transferência recebida de {contaOrigem.Name}",
            Valor = transacoes.Valor,
            TipoTransacao = transacoes.TipoTransacao,
            DirecaoTransacao = transacoes.DirecaoTransacao,
            UserId = contaDestino!.Id,
            NumeroContaDestino = transacoes.NumeroContaDestino,
            NumeroContaOrigem= transacoes.NumeroContaOrigem
            };


            user.Saldo -= transacoes.Valor;
             _bankDbContext.Transacoes.Add(transacaoContaOrigem);

            contaDestino.Saldo += transacoes.Valor;
            _bankDbContext.Transacoes.Add(transacaoContaDestino);

             _bankDbContext.SaveChanges();

            return Ok(new MessageResponse("Transferencia realizada!"));
        }

        //sAQUE
        if (transacoes.TipoTransacao.Equals(TipoTransacao.SAQUE)) {
            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            if(user.Saldo < transacoes.Valor){
                return BadRequest("Saldo insulficiente");
            }

            var transacaoSaque = new Transacoes
            {
            Historico = $"Saque realizado",
            Valor = transacoes.Valor,
            TipoTransacao = transacoes.TipoTransacao,
            DirecaoTransacao = transacoes.DirecaoTransacao,
            UserId = contaDestino!.Id,
            NumeroContaDestino = transacoes.NumeroContaDestino,
            NumeroContaOrigem= transacoes.NumeroContaOrigem
            };

            user.Saldo -= transacoes.Valor;
            _bankDbContext.Transacoes.Add(transacaoSaque);
            _bankDbContext.SaveChanges();

            return Ok(new MessageResponse("Saque realizado com sucesso!"));
        }

        //Depósito
        if (transacoes.TipoTransacao.Equals(TipoTransacao.DEPOSITO)) {
            if (user == null)
            {
            return NotFound("Usuário não encontrado.");
            }

            var transacaoDeposito = new Transacoes
            {
            Historico = $"Depósito realizado",
            Valor = transacoes.Valor,
            TipoTransacao = transacoes.TipoTransacao,
            DirecaoTransacao = transacoes.DirecaoTransacao,
            UserId = contaDestino!.Id,
            NumeroContaDestino = transacoes.NumeroContaDestino,
            NumeroContaOrigem= transacoes.NumeroContaOrigem
            };

            user.Saldo += transacoes.Valor;
            _bankDbContext.Transacoes.Add(transacaoDeposito);
            _bankDbContext.SaveChanges();

            return Ok(new MessageResponse("Depósito realizado com sucesso!"));
        }


        // _bankDbContext.Transacoes.Add(transacoes);
        // _bankDbContext.SaveChanges();        
        return Ok();
    //    return Ok("Created!");
    }

}
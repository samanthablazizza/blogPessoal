
using blogpessoal.Model;
using blogpessoal.Service;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Diagnostics.CodeAnalysis;

namespace blogpessoal.Controllers
{
    [Authorize]
    [Route("~/postagens")] //rota padrão das requisições
    [ApiController] //Controller: controlar o fluxo da aplicação
    public class PostagemController : ControllerBase 
    {
        private readonly IPostagemService _postagemService;
        private readonly IValidator<Postagem> _postagemValidator;

        public PostagemController(IPostagemService postagemService, IValidator<Postagem> postagemValidator)
        {
            _postagemService = postagemService; //aqui é como se o _postagemService fosse o this.postagemService que recebe o postagemService
            _postagemValidator = postagemValidator;
        }
        [HttpGet] //rota de busca de informações
        public async Task<ActionResult> GetAll() //async é a chave que permite que o await seja usado
        {
            return Ok(await _postagemService.GetAll()); //await espera que a ação seja finalizada
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var Resposta = await _postagemService.GetById(id);

            if (Resposta is null) //se resposta for nula
            {
                return NotFound("Postagem não Encontrada!");
            }

            return Ok(Resposta);
        }

        [HttpGet("titulo/{titulo}")]
        public async Task<ActionResult> GetByTitulo(string titulo)
        {
            return Ok(await _postagemService.GetByTitulo(titulo));
        }

        [HttpPost]
        public async Task<ActionResult> Create ([FromBody] Postagem postagem)
        {
            var validarPostagem = await _postagemValidator.ValidateAsync(postagem); //verifica as validações que especificamos

            if (!validarPostagem.IsValid) //validações inválidas
            {
                return StatusCode(StatusCodes.Status400BadRequest, validarPostagem);
            }

            await _postagemService.Create(postagem);
            var Resposta = await _postagemService.Create(postagem);

            if(Resposta is null)
            {
                return BadRequest("Tema não encontrado!");
            }

            return CreatedAtAction (nameof(GetById), new { id = postagem.Id }, postagem);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Postagem postagem)
        {
            if (postagem.Id == 0)
            {
                return BadRequest("Id da Postagem é inválido");
            }

            var validarPostagem = await _postagemValidator.ValidateAsync(postagem);

            if (!validarPostagem.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validarPostagem);
            }

            var Resposta = await _postagemService.Update(postagem);

            if (Resposta is null)
            {
                return NotFound("Postagem e/ou Tema não encontrado!");
            }
            return Ok(Resposta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var BuscaPostagem = await _postagemService.GetById(id);
            
            if (BuscaPostagem is null)
            {
                return NotFound("Postagem não foi encontrada!");
            }

            await _postagemService.Delete(BuscaPostagem);

            return NoContent();

        }
    }
}

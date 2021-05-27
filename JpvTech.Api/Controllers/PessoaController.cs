using JpvTech.Domain.Commands;
using JpvTech.Domain.Entities;
using JpvTech.Domain.Handlers;
using JpvTech.Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace JpvTech.Api.Controllers
{
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [Route("pessoas")]
        [HttpGet]
        public IEnumerable<Pessoa> GetAll(
        [FromServices] IPessoaRepository repository)

        {
            return repository.GetList();
        }

        [Route("pessoa/criar")]
        [HttpPost]
        public GenericCommandResult CadastroPessoa(
         [FromBody] CadastroPessoaCommand command,
         [FromServices] PessoaHandler handler)

        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("pessoa/atualiza")]
        public GenericCommandResult AtualizaPessoa(
        [FromBody] UpdatePessoaCommand command,
         [FromServices] PessoaHandler handler)

        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("pessoa/{id:guid}")]
        [HttpGet]
        public ActionResult GetById(Guid id,
        [FromServices] IPessoaRepository repository)

        {
            var getById = repository.GetById(id);
            return Ok(getById);
        }

        [Route("pessoa/deleta/{id:guid}")]
        [HttpDelete]
        public IActionResult DeletaPessoa(Guid id,
            [FromServices] IPessoaRepository pessoa)
        {
            pessoa.Delete(id);
            return NoContent();
        }



    }
}

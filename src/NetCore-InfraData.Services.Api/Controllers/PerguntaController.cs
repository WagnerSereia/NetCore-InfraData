using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetCore_InfraData.Application.Interfaces;
using NetCore_InfraData.Application.ViewModels;
using NetCore_InfraData.Domain.Entities;
using NetCore_InfraData.Domain.Interfaces.Services;

namespace NetCore_InfraData.Services.Api.Controllers
{
    public class PerguntasController : Controller
    {
        private readonly IPerguntaAppService _perguntaAppService;

        public PerguntasController(IPerguntaAppService perguntaAppService)
        {
            _perguntaAppService = perguntaAppService;
        }

        [HttpGet]
        [Route("todas-perguntas")]
        public ActionResult<List<PerguntaViewModel>> Get()
        {
            return _perguntaAppService.ObterTodos().ToList();
        }

        [HttpGet]
        [Route("minhas-perguntas")]
        public ActionResult<List<PerguntaViewModel>> MinhasPerguntas()
        {
            var a = User.Identity.IsAuthenticated;

            if (User.Identity.IsAuthenticated)
            {
                return _perguntaAppService.ObterMinhasPerguntas(User.Identity.Name).ToList();
            }
            return BadRequest("Usuario nao autenticado");
        }

        [HttpGet]
        [Route("minhas-perguntas-respondidas")]
        public ActionResult<List<PerguntaViewModel>> MinhasPerguntasRespondidas()
        {
            var a = User.Identity.IsAuthenticated;

            if (User.Identity.IsAuthenticated)
            {
                return _perguntaAppService.ObterMinhasPerguntas(User.Identity.Name).ToList();
            }
            return BadRequest("Usuario nao autenticado");
        }

        [HttpGet]
        [Route("obter-pergunta/{id:guid}")]
        public ActionResult<PerguntaViewModel> Get(Guid id)
        {
            return _perguntaAppService.ObterPorId(id);
        }

        [HttpPost]
        [Route("criar-pergunta")]
        public IActionResult Post(PerguntaViewModel pergunta)
        {
            if (ModelState.IsValid)
            {
                _perguntaAppService.Adicionar(pergunta);
                return Created($"/api/pergunta{pergunta.Id}", pergunta);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("atualizar-pergunta/{id}")]
        public IActionResult Put([FromRoute]Guid id, [FromBody]PerguntaViewModel pergunta)
        {
            if (ModelState.IsValid)
            {
                _perguntaAppService.Atualizar(pergunta);
                return Created($"/api/pergunta{pergunta.Id}", pergunta);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("remover-pergunta/{id}")]
        public IActionResult Delete([FromRoute]Guid id)
        {
            if (ModelState.IsValid)
            {
                _perguntaAppService.Remover(id);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
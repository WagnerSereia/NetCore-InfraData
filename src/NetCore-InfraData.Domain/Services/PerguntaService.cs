using NetCore_InfraData.Domain.Entities;
using NetCore_InfraData.Domain.Interfaces.Repositories;
using NetCore_InfraData.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace NetCore_InfraData.Domain.Services
{
    public class PerguntaService : ServiceBase<Pergunta>, IPerguntaService
    {
        private readonly IPerguntaRepository _perguntaRepository;

        public PerguntaService(IPerguntaRepository perguntaRepository)
            : base(perguntaRepository)
        {
            _perguntaRepository = perguntaRepository;
        }

        public IEnumerable<Pergunta> ObterMinhasPerguntas(String autor)
        {
            return _perguntaRepository.ObterMinhasPerguntas(autor);
        }

        public override Pergunta Adicionar(Pergunta pergunta)
        {
            if (!pergunta.EhValido())
                return pergunta;

            if (!pergunta.ValidationResult.IsValid)
                return pergunta;

            return base.Adicionar(pergunta);
        }

        public override Pergunta Atualizar(Pergunta pergunta)
        {
            if (!pergunta.EhValido())
                return pergunta;

            if (!pergunta.ValidationResult.IsValid)
                return pergunta;

            return base.Atualizar(pergunta);
        }
    }
}

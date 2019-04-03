using NetCore_InfraData.Domain.Entities;
using NetCore_InfraData.Domain.Interfaces.Repositories;
using NetCore_InfraData.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;


namespace NetCore_InfraData.Domain.Services
{
    public class RespostaService : ServiceBase<Resposta>, IRespostaService
    {
        private readonly IRespostaRepository _respostaRepository;

        public RespostaService(IRespostaRepository respostaRepository)
            : base(respostaRepository)
        {
            _respostaRepository = respostaRepository;
        }

        public IEnumerable<Resposta> ObterMinhasRespostas(String autor)
        {
            return _respostaRepository.ObterMinhasRespostas(autor);
        }
    }
}

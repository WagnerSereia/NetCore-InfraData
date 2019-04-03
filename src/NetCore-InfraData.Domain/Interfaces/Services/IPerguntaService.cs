using NetCore_InfraData.Domain.Entities;
using System;
using System.Collections.Generic;


namespace NetCore_InfraData.Domain.Interfaces.Services
{
    public interface IPerguntaService : IServiceBase<Pergunta>
    {
        IEnumerable<Pergunta> ObterMinhasPerguntas(String autor);
    }
}

using NetCore_InfraData.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace NetCore_InfraData.Application.Interfaces
{
    public interface IPerguntaAppService : IServiceBaseApp<PerguntaViewModel>
    {
        IEnumerable<PerguntaViewModel> ObterMinhasPerguntas(String autor);
    }
}

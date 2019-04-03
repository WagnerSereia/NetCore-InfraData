using NetCore_InfraData.Domain.Entities;
using System;
using System.Collections.Generic;

namespace NetCore_InfraData.Domain.Interfaces.Repositories
{
    public interface IRespostaRepository : IRepositoryBase<Resposta>
    {
        IEnumerable<Resposta> ObterMinhasRespostas(String autor);
    }
}

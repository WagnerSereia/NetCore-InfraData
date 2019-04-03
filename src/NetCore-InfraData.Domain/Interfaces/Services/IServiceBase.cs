using System;
using System.Collections.Generic;

namespace NetCore_InfraData.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        TEntity Atualizar(TEntity obj);
        TEntity Remover(Guid id);
        void Dispose();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore_InfraData.Application.Interfaces
{
    public interface IServiceBaseApp<TEntity> where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        TEntity Atualizar(TEntity obj);
        TEntity Remover(Guid id);
        void Dispose();
    }
}

using NetCore_InfraData.Domain.Interfaces.Repositories;
using NetCore_InfraData.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace NetCore_InfraData.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;


        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual TEntity Adicionar(TEntity obj)
        {
            _repository.Adicionar(obj);
            return null;
        }

        public TEntity ObterPorId(Guid id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public virtual TEntity Atualizar(TEntity obj)
        {
            return _repository.Atualizar(obj);
        }

        public virtual TEntity Remover(Guid id)
        {
            _repository.Remover(id);
            return null;
        }

        public void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

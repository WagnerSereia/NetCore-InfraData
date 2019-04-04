using NetCore_InfraData.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore_InfraData.Application.Services
{
    public class TesteAppService
    {
        private readonly OperationService _operationService;
        private readonly ITesteTransient _transientOperation;
        private readonly ITesteScoped _scopedOperation;
        private readonly ITesteSingleton _singletonOperation;
        private readonly ITesteSingletonInstance _singletonInstanceOperation;

        public TesteAppService(OperationService operationService,
            ITesteTransient transientOperation,
            ITesteScoped scopedOperation,
            ITesteSingleton singletonOperation,
            ITesteSingletonInstance singletonInstanceOperation)
        {
            _operationService = operationService;
            _transientOperation = transientOperation;
            _scopedOperation = scopedOperation;
            _singletonOperation = singletonOperation;
            _singletonInstanceOperation = singletonInstanceOperation;
        }

        public IEnumerable<string> testeLifeStyle()
        {
            List<string> tipos = new List<string>();
            tipos.Add("Transient: " + _transientOperation.Id);
            tipos.Add("Scoped: " + _scopedOperation.Id);
            tipos.Add("Singleton: " + _singletonOperation.Id);
            tipos.Add("SingletonInstance: " + _singletonInstanceOperation.Id);

            tipos.Add("ServiceTransient : " + _operationService.TransientOperation.Id);
            tipos.Add("ServiceScoped : " + _operationService.ScopedOperation.Id);
            tipos.Add("ServiceSingleton : " + _operationService.SingletonOperation.Id);
            tipos.Add("ServiceSingletonInstance : " + _operationService.SingletonInstanceOperation.Id);

            return tipos;
        }
    }
}


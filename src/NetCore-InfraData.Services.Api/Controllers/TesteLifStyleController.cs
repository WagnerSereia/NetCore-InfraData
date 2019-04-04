using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCore_InfraData.Application.Services;
using NetCore_InfraData.Domain.Interfaces.Repositories;

namespace NetCore_InfraData.Services.Api.Controllers
{
    public class TesteLifStyleController : Controller
    {
        private readonly OperationService _operationService;
        private readonly ITesteTransient _transientOperation;
        private readonly ITesteScoped _scopedOperation;
        private readonly ITesteSingleton _singletonOperation;
        private readonly ITesteSingletonInstance _singletonInstanceOperation;

        public TesteLifStyleController(OperationService operationService,
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

        [HttpGet]
        [Route("teste-LifeStyle")]
        public ActionResult<List<string>> Index()
        {
            TesteAppService teste = new TesteAppService(_operationService, _transientOperation, _scopedOperation, _singletonOperation, _singletonInstanceOperation);
            return teste.testeLifeStyle().ToList();
        }
    }
}
using AutoMapper;
using NetCore_InfraData.Application.Interfaces;
using NetCore_InfraData.Application.ViewModels;
using NetCore_InfraData.Data.Interfaces;
using NetCore_InfraData.Domain.Entities;
using NetCore_InfraData.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore_InfraData.Application.Services
{
    public class PerguntaAppService : AppService, IPerguntaAppService
    {
        private readonly IPerguntaService _perguntaService;
        private readonly IMapper _mapper;

        public PerguntaAppService(IPerguntaService perguntaService, IMapper mapper, IUnitOfWork uow)
            : base(uow)
        {
            _perguntaService = perguntaService;
            _mapper = mapper;
        }

        public PerguntaViewModel Adicionar(PerguntaViewModel perguntaViewModel)
        {
            var pergunta = _mapper.Map<PerguntaViewModel, Pergunta>(perguntaViewModel);
            var perguntasReturn = _perguntaService.Adicionar(pergunta);

            if (perguntasReturn.ValidationResult.IsValid)
            {
                Commit();
            }

            perguntaViewModel = _mapper.Map<Pergunta, PerguntaViewModel>(perguntasReturn);
            return perguntaViewModel;
        }

        public PerguntaViewModel Atualizar(PerguntaViewModel perguntaViewModel)
        {
            var pergunta = Mapper.Map<PerguntaViewModel, Pergunta>(perguntaViewModel);
            var perguntasReturn = _perguntaService.Atualizar(pergunta);

            if (perguntasReturn.ValidationResult.IsValid)
            {
                Commit();
            }

            perguntaViewModel = _mapper.Map<Pergunta, PerguntaViewModel>(perguntasReturn);
            return perguntaViewModel;
        }


        public IEnumerable<PerguntaViewModel> ObterMinhasPerguntas(string autor)
        {
            var perguntasReturn = _mapper.Map<List<PerguntaViewModel>>(_perguntaService.ObterMinhasPerguntas(autor));

            return perguntasReturn;
        }

        public PerguntaViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<PerguntaViewModel>(_perguntaService.ObterPorId(id));
        }

        public IEnumerable<PerguntaViewModel> ObterTodos()
        {
            return _mapper.Map<List<PerguntaViewModel>>(_perguntaService.ObterTodos());
        }

        public PerguntaViewModel Remover(Guid id)
        {
            var perguntasReturn = _perguntaService.Remover(id);

            if (perguntasReturn.ValidationResult.IsValid)
            {
                Commit();
            }
            var perguntaViewModel = _mapper.Map<Pergunta, PerguntaViewModel>(perguntasReturn);

            return perguntaViewModel;
        }

        public void Dispose()
        {
            _perguntaService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

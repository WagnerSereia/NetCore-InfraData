
using System;

namespace NetCore_InfraData.Application.ViewModels
{
    public class RespostaViewModel
    {
        public RespostaViewModel()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Autor { get; set; }
        public string Descricao { get; set; }
        public Guid PerguntaId { get; set; }
        public PerguntaViewModel Pergunta { get; set; }
    }
}
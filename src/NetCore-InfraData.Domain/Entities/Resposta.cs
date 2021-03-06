﻿using FluentValidation;
using NetCore_InfraData.Domain.Entities.Model;
using System;

namespace NetCore_InfraData.Domain.Entities
{
    public class Resposta : Entity<Resposta>
    {
        public Resposta(string autor, string descricao)
        {
            Autor = autor;
            Descricao = descricao;
        }
        public Resposta()
        {
        }
        public string Autor { get; private set; }
        public string Descricao { get; private set; }
        public Pergunta Pergunta { get; private set; }
        public Guid PerguntaId { get; private set; }
        public override bool EhValido()
        {
            RuleFor(c => c.Pergunta)
               .Null().WithMessage("A Pergunta precisa ser fornecida");

            RuleFor(c => c.Autor)
               .NotEmpty().WithMessage("O autor precisa ser fornecido")
               .Length(2, 150).WithMessage("O autor precisa ter entre 2 e 150 caracteres");

            RuleFor(c => c.Descricao)
               .NotEmpty().WithMessage("A Descrição precisa ser fornecida")
               .Length(2, 150).WithMessage("A Descrição precisa ter entre 2 e 150 caracteres");

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }
        public override string ToString()
        {
            return $"[{Id}]-{Descricao}";
        }
    }
}

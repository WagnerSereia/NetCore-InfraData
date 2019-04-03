using FluentValidation;
using NetCore_InfraData.Domain.Entities.Model;
using System;
using System.Collections.Generic;

namespace NetCore_InfraData.Domain.Entities
{
    public class Pergunta : Entity<Pergunta>
    {
        public Pergunta(string autor, string titulo, string descricao)
        {
            Autor = autor;
            Titulo = titulo;
            Descricao = descricao;

            Tags = new List<string>();
            Respostas = new List<Resposta>();
        }
        public Pergunta()
        {
            Tags = new List<string>();
            Respostas = new List<Resposta>();
        }
        public string Autor { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public Guid CategoriaId { get; private set; }
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<string> Tags { get; private set; }
        public virtual ICollection<Resposta> Respostas { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public override bool EhValido()
        {
            RuleFor(c => c.Autor)
               .NotEmpty().WithMessage("O Autor precisa ser fornecida")
               .Length(2, 150).WithMessage("A Autor precisa ter entre 2 e 150 caracteres");

            RuleFor(c => c.Descricao)
               .NotEmpty().WithMessage("A Descrição precisa ser fornecida")
               .Length(2, 150).WithMessage("A Descrição precisa ter entre 2 e 150 caracteres");

            RuleFor(c => c.Titulo)
              .NotEmpty().WithMessage("O Título precisa ser fornecido")
              .Length(2, 150).WithMessage("O Título precisa ter entre 2 e 150 caracteres");

            RuleFor(c => c.Descricao)
               .NotEmpty().WithMessage("A Categoria precisa ser fornecida");

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        public override string ToString()
        {
            return $"[{Id}]-{Titulo}";
        }
    }
}

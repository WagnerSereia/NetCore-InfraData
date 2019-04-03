using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore_InfraData.Domain.Entities;
using NetCore_InfraData.Infra.Data.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore_InfraData.Infra.Data.EntityConfig
{
    public class RespostaMap : EntityTypeConfiguration<Resposta>
    {
        public override void Map(EntityTypeBuilder<Resposta> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Autor)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(155)");

            builder.Ignore(c => c.Pergunta);
            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.CascadeMode);

            builder.HasOne(e => e.Pergunta)
               .WithMany(e => e.Respostas)
               .HasForeignKey(e => e.PerguntaId);

            builder.ToTable("Respostas");
        }

    }
}

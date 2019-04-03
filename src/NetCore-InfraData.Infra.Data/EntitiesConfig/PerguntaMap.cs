using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore_InfraData.Domain.Entities;
using NetCore_InfraData.Infra.Data.Extensions;

namespace NetCore_InfraData.Infra.Data.EntityConfig
{
    public class PerguntaMap : EntityTypeConfiguration<Pergunta>
    {
        public override void Map(EntityTypeBuilder<Pergunta> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Autor)
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Titulo)
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Tags)
                .HasColumnType("varchar(300)");

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Ignore(e => e.Tags);
            builder.Ignore(e => e.Categoria);
            builder.Ignore(e => e.ValidationResult);
            builder.Ignore(e => e.CascadeMode);
            builder.Ignore(e => e.Respostas);

            builder.ToTable("Perguntas");
        }
    }
}
using Microsoft.EntityFrameworkCore;
using NetCore_InfraData.Domain.Entities;
using NetCore_InfraData.Infra.Data.EntityConfig;
using NetCore_InfraData.Infra.Data.Extensions;
using System;
using System.Linq;

namespace NetCore_InfraData.Data.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
            //this.Configuration.LazyLoadingEnabled = false;

            if (!Categoria.Any())
            {
                Categoria.Add(new Categoria("Banco de Dados", "Perguntas relacionados com banco de dados"));
                Categoria.Add(new Categoria("Linguagem de programação", "Perguntas sobre as mais diversas linguagens de programação"));
                Categoria.Add(new Categoria("IoT", "Perguntas sobre sensores, automação e internet"));
                Categoria.Add(new Categoria("WEB", "Perguntas sobre desenvolvimento WEB"));

                SaveChanges();
            }
        }

        public DbSet<Pergunta> Pergunta { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Resposta> Resposta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new PerguntaMap());
            modelBuilder.AddConfiguration(new CategoriasMap());
            modelBuilder.AddConfiguration(new RespostaMap());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }

    }
}

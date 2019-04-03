using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore_InfraData.Application.Interfaces;
using NetCore_InfraData.Application.Services;
using NetCore_InfraData.Data.Context;
using NetCore_InfraData.Data.Interfaces;
using NetCore_InfraData.Data.Repositories;
using NetCore_InfraData.Data.UnitOfWork;
using NetCore_InfraData.Domain.Interfaces.Repositories;
using NetCore_InfraData.Domain.Interfaces.Services;
using NetCore_InfraData.Domain.Services;
using System.IO;

namespace NetCore_InfraData.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASPNET            
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

            //Application - Service
            services.AddTransient<IPerguntaAppService, PerguntaAppService>();

            //Domain - Service
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddTransient<IPerguntaService, PerguntaService>();
            services.AddTransient<IRespostaService, RespostaService>();
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<IUserService, UserService>();


            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddTransient<IPerguntaRepository, PerguntaRepository>();
            services.AddTransient<IRespostaRepository, RespostaRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        }
    }
}

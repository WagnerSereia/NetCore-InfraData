using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_InfraData.Services.Api.Configurations.Swagger
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "NetCore-InfraData API",
                    Description = "API para demonstração de um projeto de Backend usando Dapper no contexto de Data",
                    TermsOfService = "Para uso exclusivo de estudo",
                    Contact = new Contact { Name = "Wagner Sereia", Email = "wsinfo@msn.com", Url = "https://github.com/WagnerSereia/NetCore-InfraData" },
                    License = new License { Name = "MIT", Url = "https://github.com/WagnerSereia/NetCore-InfraData/licensa" }
                });
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace jwtAuthApi.Application.Middlewares
{
    [ExcludeFromCodeCoverage]
    public static class SwaggerMiddlerware
    {
        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "jwtAuthApi",
                        Version = "v1",
                        Description = "Auhorization Jwt Api",
                        Contact = new Contact
                        {
                            Name = "Alexandre Brandão Lustosa",
                            Url = "https://github.com/alexandrebl/jwtAuthApi"
                        }
                    });

                var caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                var caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"jwtAuthApi.Application.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });
        }
        public static void UseSwaggerApp(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Auhorization Jwt Api");
            });
        }
    }
}

using jwtAuthApi.BusinessCore;
using jwtAuthApi.BusinessCore.Interfaces;
using jwtAuthApi.Domain.Entities;
using jwtAuthApi.Repository;
using jwtAuthApi.Repository.Interfaces;
using jwtAuthApi.Services.Interfaces;
using jwtAuthApi.Services.Layers;
using Microsoft.Extensions.DependencyInjection;

namespace jwtAuthApi.Application.Middlewares
{
    /// <summary>
    /// Classe de inserção de injeção de dependência
    /// </summary>
    public static class DependencyInjectionMiddleware
    {
        /// <summary>
        /// Método de inserção de injeção de dependência
        /// </summary>
        /// <param name="services">serviços</param>
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<IRepository<User>, UserMemoryRepository>();
            services.AddTransient<IAuthBusinessCore, AuthBusinessCore>();
            services.AddTransient<IUserServices, UserServices>();
        }
    }
}

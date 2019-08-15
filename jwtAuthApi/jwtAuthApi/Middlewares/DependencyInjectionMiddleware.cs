using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtAuthApi.BusinessCore;
using jwtAuthApi.BusinessCore.Interfaces;
using jwtAuthApi.Domain.Entities;
using jwtAuthApi.Repository.Interfaces;
using jwtAuthApi.Repository.Layers;
using jwtAuthApi.Services.Interfaces;
using jwtAuthApi.Services.Layers;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace jwtAuthApi.Application.Middlewares
{
    public static class DependencyInjectionMiddleware
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<IRepository<User>, MemoryRepository<User>>();
            services.AddTransient<IAuthBusinessCore, AuthBusinessCore>();
            services.AddTransient<IUserServices, UserServices>();
        }
    }
}

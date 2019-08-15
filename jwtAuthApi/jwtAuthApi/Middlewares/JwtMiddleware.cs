using Microsoft.Extensions.DependencyInjection;

namespace jwtAuthApi.Application.Middlewares
{
    public static class JwtMiddleware
    {
        public static void AddJwtMiddleware(this IServiceCollection services)
        {
            UseJwtMiddleware(services);
        }
        private static void UseJwtMiddleware(IServiceCollection services)
        {
            
        }
    }
}

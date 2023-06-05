using FinishLine.Models;
using FinishLine.Services.Auth;
using FinishLine.Services.Generics;

namespace FinishLine.Api.Bootstrap
{
    public class DependencyInjector
    {
        public static void InjectRepositories(IServiceCollection services)
        {
            
        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<IServiceGeneric<AppUser>, ServiceGeneric<AppUser>>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}

using FinishLine.Models;
using FinishLine.Repositories;
using FinishLine.Repositories.Generics;
using FinishLine.Services.Auth;
using FinishLine.Services.Generics;

namespace FinishLine.Api.Bootstrap
{
    public class DependencyInjector
    {
        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddScoped<IRepositoryGeneric<AppUser>, FinishLineRepository<AppUser>>();
            services.AddScoped<IRepositoryGeneric<Competition>, FinishLineRepository<Competition>>();

        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<IServiceGeneric<AppUser>, ServiceGeneric<AppUser>>();
            services.AddScoped<IServiceGeneric<Competition>, ServiceGeneric<Competition>>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}

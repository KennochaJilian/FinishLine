using FinishLine.Models;
using FinishLine.Services;
using FinishLine.Services.Generics;
using FinishLine.Services.Interfaces;
using Newtonsoft.Json.Linq;

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
        }
    }
}

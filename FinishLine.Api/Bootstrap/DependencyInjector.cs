using FinishLine.Models;
using FinishLine.Services.Generics;
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
        }
    }
}

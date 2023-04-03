using FinishLine.Api.Bootstrap;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FinishLine.Api;
    public class Startup
    {
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        DependencyInjector.InjectRepositories(services);
        DependencyInjector.InjectServices(services);
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

    }
    public void Configure(IApplicationBuilder app)
    {

        app.UseStaticFiles();

        app.UseAuthentication();      

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors("CorsPolicy");
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
        });

    }
}


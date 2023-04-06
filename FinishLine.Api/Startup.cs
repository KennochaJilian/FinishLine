using FinishLine.Api.Bootstrap;
using FinishLine.Models;
using Microsoft.EntityFrameworkCore;
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


        var connectionString = Configuration.GetConnectionString("Local");
        if (connectionString != null)
        {
            services.AddDbContext<FinishLineDbContext>(options => options.UseMySQL(
                connectionString, x => x.MigrationsAssembly("FinishLine.Models")));
        }

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


using FinishLine.Api.Bootstrap;
using FinishLine.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
        services.AddIdentity<AppUser, Role>()
            .AddEntityFrameworkStores<FinishLineDbContext>()
            .AddDefaultTokenProviders();

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

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "your-issuer",
                ValidAudience = "your-audience",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-signing-key"))
            };
        });


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


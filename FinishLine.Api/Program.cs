using FinishLine.Api;
using Microsoft.AspNetCore;

tryMain(args);
static void tryMain(string[] args) {
    CreateHostBuilder(args).Build().Run();
}

static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
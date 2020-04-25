using Evercraft.Web.Characters;
using Evercraft.Web.Common.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Evercraft.Web
{
    public class Startup
    {
        private readonly IConfiguration _config;

        private string DatabaseConnectionString => _config["DB_CONNECTION_STRING"];

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EvercraftContext>(opts =>
            {
                opts.UseNpgsql(DatabaseConnectionString, postgres =>
                {
                    postgres.MigrationsAssembly(typeof(Startup).Assembly.GetName().Name);
                });
            });
            services.AddControllersWithViews()
                .AddRazorOptions(opts =>
                {
                    opts.ViewLocationFormats.Add("/{1}/Views/{0}.cshtml");
                    opts.ViewLocationFormats.Add("/Shared/Views/_Layout.cshtml");
                });
            services.AddTransient<CreateCharacterHandler>()
                .AddTransient<GetAllCharactersHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.MigrateDatabaseAsync<EvercraftContext>().Wait();
            app.UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapFallbackToController("StartGame", "Game");
                });
        }
    }
}
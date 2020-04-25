using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Evercraft.Dice
{
    public class Startup
    {
        private readonly Random _randomizer = new Random();
        
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapPost("/roll", async context =>
                {
                    context.Response.Headers["Content-Type"] = MediaTypeNames.Application.Json;
                    await context.Response.WriteAsync(JsonSerializer.Serialize(new RollModel
                    {
                        Value = _randomizer.Next(20)
                    }));
                });
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.Extensions.Logging;

namespace ASP.Net_Core
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMessageWriter, LoggingMessageWriter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();


            app.UseExceptionMiddleware();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Middleware1: Incoming Request\n");
                throw new Exception("This is an exception message");
                await next();
                await context.Response.WriteAsync("Middleware1: Outgoing Response\n");
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Middleware2: Incoming Request\n");
                await next();        
                await context.Response.WriteAsync("Middleware2: Outgoing Response\n");
            });
            app.Run(async (context) =>
            {
                throw new Exception("This is an exception message");
                await context.Response.WriteAsync("Middleware3: Incoming Request handled and response generated\n");
            });
            
        }

    }
}

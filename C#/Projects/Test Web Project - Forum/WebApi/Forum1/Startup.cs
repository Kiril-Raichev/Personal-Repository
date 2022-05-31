using Forum1.Data;
using Forum1.Hellper;
using Forum1.Models.Mappers;
using Forum1.Repositories;
using Forum1.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Forum1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ancient culture and tradition", Version = "v1" });
            });

            // Adds controllers and views
            services.AddControllersWithViews()
                // This prevents the application from crashing when displaying mutually related entities
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);


            //Server = DESKTOP-ERMR02D
            //Database = Forum1Db
            //Trust_Connection = True
            var connectionString = @"Server=DESKTOP-ERMR02D;Database=Forum1Db;Trusted_Connection = True";


            //EF
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
            
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(1000);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;  
            });


            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            //Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();
            //Helpers
            services.AddTransient<AuthorisationHelper>();
            services.AddTransient<CommentMapper>();
            services.AddTransient<PostMapper>();
            services.AddTransient<UserMapper>();
            services.AddTransient<ReactionMapper>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseDeveloperExceptionPage();
            // Enables the views to use resources from wwwroot
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

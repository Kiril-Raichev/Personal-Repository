using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Poodle_E_Learning_Platform.Data;
using Poodle_E_Learning_Platform.Helpers;
using Poodle_E_Learning_Platform.Repositories;
using Poodle_E_Learning_Platform.Repositories.Contracts;
using Poodle_E_Learning_Platform.Services;
using Poodle_E_Learning_Platform.Services.Contracts;
using Poodle_E_Learning_Platform.Web.Helpers;
using System;

namespace Poodle_E_Learning_Platform.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
             //Controller with views
            services.AddControllersWithViews();
             //NewtonSoftJson
            services.AddControllers().AddNewtonsoftJson(options =>
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddControllersWithViews();
            //SQL
           services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //Session
            services.AddSession(options =>
            {
                // With IdleTimeout you can change the number of seconds after which the session expires.
                // The seconds reset every time you access the session.
                // This only applies to the session, not the cookie.
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
                options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax;
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            // Allow dependency inject the HttpContext into AuthorizationHelper
            services.AddHttpContextAccessor();
           
            //Repos
           services.AddScoped<IUsersRepository, UsersRepository>();
           services.AddScoped<ICourseRepository, CourseRepository>();
           services.AddScoped<IUserCourseRepository, UserCourseRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();
            //Servieces
           services.AddScoped<IUsersService, UsersService>();
           services.AddScoped<ICourseService, CourseService>();
           services.AddScoped<ISectionService, SectionService>();
           
            //Helpers
            services.AddTransient<ModelMapper>();
            services.AddTransient<AuthorizationHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

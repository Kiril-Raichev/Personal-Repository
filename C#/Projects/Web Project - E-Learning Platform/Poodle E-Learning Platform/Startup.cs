using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Poodle_E_Learning_Platform.Data;
using Poodle_E_Learning_Platform.Repositories;
using Poodle_E_Learning_Platform.Repositories.Contracts;
using Poodle_E_Learning_Platform.Services;
using Poodle_E_Learning_Platform.Services.Contracts;

namespace Poodle_E_Learning_Platform
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
            services.AddControllers().AddNewtonsoftJson(options =>
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //Repos
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IUserCourseRepository, UserCourseRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();
            //Seervices
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ISectionService, SectionService>();
            //Helpers
            services.AddSwaggerGen(option => { option.SwaggerDoc("v1", new OpenApiInfo { Title = "Poodle E-Learning Platform", Version = "v1" }); });

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "v1");
            });

        }
    }
}

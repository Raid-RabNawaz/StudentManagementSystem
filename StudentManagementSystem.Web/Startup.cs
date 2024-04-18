using Microsoft.AspNetCore.Builder;
using StudentManagementSystem.Web.Repositories;
using StudentManagementSystem.Web.Services;

namespace StudentManagementSystem.Web
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
            // Add services to the DI container here
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();

            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICourseService, CourseService>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Add production error handling middleware here
            }

            // Configure middleware components here
        }
    }
}

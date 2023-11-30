using LearningApp.Application;
using LearningApp.Application.DataTransferObjects.Shared;
using LearningApp.Data;
using LearningApp.Web.Extensions;
using LearningApp.Web.Middlewares;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationLayer();

            // setup vercel token
            Vercel.BaseUrl = Configuration["Vercel:BaseUrl"];

            services.AddControllers();
            services.AddSwaggerGen();

            // add service for db connection
            services.AddDbContext<EFDataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionStringMssql")));

            services.AddCors();
            services.AddServicesConfig();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LearningApp.Web v1"));
            }

            app.UseRouting();

            // -- Setup Cors here 
            /*app.UseCors(x => x
                .WithOrigins("http://0.0.0.0:80",
                "http://3.109.132.170:80",
                "http://192.168.1.6",
                "http://localhost:80")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());*/

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

    }
}

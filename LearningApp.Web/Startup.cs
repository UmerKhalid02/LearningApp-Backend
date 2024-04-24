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

            // vercel setup
            Vercel.BaseUrl = Configuration["Vercel:BaseUrl"];
            Vercel.AccessToken = Configuration["Vercel:ACCESS_TOKEN"];

            services.AddControllers();
            services.AddSwaggerGen();

            // add service for db connection
            services.AddDbContext<EFDataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionStringMssql")));

            // settings for JWT Secret Key
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = System.Text.Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddJwtTokenAuthentication(Configuration, key);
            services.AddHttpContextAccessor();

            // quartz setup
            services.AddQuartzConfig();

            services.AddCors();
            services.AddServicesConfig();
            services.AddSwaggerConfiguration();
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

            app.UseSwaggerSetup();
            app.UseRouting();

            // -- Setup Cors here 
            app.UseCors(x => x
                .WithOrigins(
                "http://127.0.0.1:8000",
                "http://127.0.0.1:8001",
                "http://127.0.0.1:8081",
                "http://127.0.0.1:5000",
                "http://127.0.0.1:5173",
                "http://localhost:5173",
                "http://127.0.0.1:5500",
                "http://127.0.0.1",
                "http://localhost")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseMiddleware<AuthorizationMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

    }
}

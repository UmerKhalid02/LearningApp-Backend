using LearningApp.Data.IRepositories.IProblemRepository;
using LearningApp.Data.Repositories.ProblemRepository;
using LearningApp.Web.Modules.Problems;

namespace LearningApp.Web.Extensions
{
    public static class ServicesConfig
    {
        public static IServiceCollection AddServicesConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IProblemService, ProblemService>();
            services.AddScoped<IProblemRepository, ProblemRepository>();

            return services;
        }
    }
}

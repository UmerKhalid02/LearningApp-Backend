using LearningApp.Data.IRepositories.IAuthenticationRepository;
using LearningApp.Data.IRepositories.ILeaderboardRepository;
using LearningApp.Data.IRepositories.ILessonRepository;
using LearningApp.Data.IRepositories.IProblemRepository;
using LearningApp.Data.IRepositories.ITopicRepository;
using LearningApp.Data.Repositories.AuthenticationRepository;
using LearningApp.Data.Repositories.LeaderboardRepository;
using LearningApp.Data.Repositories.LessonRepository;
using LearningApp.Data.Repositories.ProblemRepository;
using LearningApp.Data.Repositories.TopicRepository;
using LearningApp.Web.Modules.Authentication;
using LearningApp.Web.Modules.Languages.Python;
using LearningApp.Web.Modules.Leaderboard;
using LearningApp.Web.Modules.Lessons;
using LearningApp.Web.Modules.Problems;
using LearningApp.Web.Modules.Topics;

namespace LearningApp.Web.Extensions
{
    public static class ServicesConfig
    {
        public static IServiceCollection AddServicesConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

            services.AddScoped<IProblemService, ProblemService>();
            services.AddScoped<IProblemRepository, ProblemRepository>();

            services.AddScoped<IPythonService, PythonService>();

            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<ITopicRepository, TopicRepository>();

            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<ILessonRepository, LessonRepository>();

            services.AddScoped<ILeaderboardService, LeaderboardService>();
            services.AddScoped<ILeaderboardRepository, LeaderboardRepository>();

            return services;
        }
    }
}

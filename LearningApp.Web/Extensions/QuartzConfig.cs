using LearningApp.Web.CronJobs;
using Quartz;

namespace LearningApp.Web.Extensions
{
    public static class QuartzConfig
    {
        public static IServiceCollection AddQuartzConfig(this IServiceCollection services)
        {
            services.AddQuartz(opt =>
            {
                opt.UseMicrosoftDependencyInjectionJobFactory();
                var jobKey = new JobKey("ResetLeaderboardJob");
                opt.AddJob<ResetLeaderboardJob>(options => options.WithIdentity(jobKey));
                opt.AddTrigger(options =>
                {
                    options.ForJob(jobKey)
                        .WithIdentity("ResetLeaderboardJobTrigger")
                        .WithCronSchedule(CronScheduleBuilder.WeeklyOnDayAndHourAndMinute(DayOfWeek.Monday, 0, 0));
                });
            });

            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

            return services;
        }
    }
}

using LearningApp.Data.IRepositories.ILeaderboardRepository;
using Quartz;

namespace LearningApp.Web.CronJobs
{
    [DisallowConcurrentExecution]
    public class ResetLeaderboardJob : IJob
    {
        private readonly ILeaderboardRepository _leaderboardRepository;
        public ResetLeaderboardJob(ILeaderboardRepository leaderboardRepository)
        {
            _leaderboardRepository = leaderboardRepository;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            await _leaderboardRepository.ResetLeaderboard();
        }
    }
}

using LearningApp.Application.DataTransferObjects.LeaderboardDTO;
using LearningApp.Application.Wrappers;

namespace LearningApp.Web.Modules.Leaderboard
{
    public interface ILeaderboardService
    {
        public Task<Response<List<LeaderboardResponseDTO>>> GetLeaderboard();
    }
}

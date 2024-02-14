using LearningApp.Web.Modules.Common;
using Microsoft.AspNetCore.Mvc;

namespace LearningApp.Web.Modules.Leaderboard
{
    [Route("api/v1/leaderboard")]
    public class LeaderboardController : BaseController
    {
        private readonly ILeaderboardService _leaderboardService;
        public LeaderboardController(ILeaderboardService leaderboardService)
        {
            _leaderboardService = leaderboardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLeaderboard()
        {
            var response = await _leaderboardService.GetLeaderboard();
            return Ok(response);
        }

    }
}

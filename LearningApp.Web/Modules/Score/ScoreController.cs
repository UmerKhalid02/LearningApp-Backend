using LearningApp.Application.DataTransferObjects.ScoreDTO;
using LearningApp.Web.Modules.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningApp.Web.Modules.Score
{
    [Route("api/v1/result")]
    public class ScoreController : BaseController
    {
        private readonly IScoreService _scoreService;
        public ScoreController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }

        [Authorize(Roles = "ST, TR")]
        [HttpPost]
        public async Task<IActionResult> CalculateScore([FromBody] CalculateScoreRequestDTO request)
        {
            Guid userId = this.GetUserId();
            var response = await _scoreService.CalculateScore(userId, request);
            return Ok(response);
        }
    }
}

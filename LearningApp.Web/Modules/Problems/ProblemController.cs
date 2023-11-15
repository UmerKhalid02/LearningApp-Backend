using LearningApp.Application.DataTransferObjects.ProblemDTO;
using LearningApp.Web.Modules.Common;
using Microsoft.AspNetCore.Mvc;

namespace LearningApp.Web.Modules.Problems
{
    [Route("api/v1/problems")]
    public class ProblemController : BaseController
    {
        private readonly IProblemService _problemService;
        public ProblemController(IProblemService problemService)
        {
            _problemService = problemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProblems()
        {
            var response = await _problemService.GetAllProblems();
            return Ok(response);
        }

        [HttpGet("{problemId}")]
        public async Task<IActionResult> GetProblemById(Guid problemId)
        {
            var response = await _problemService.GetProblemById(problemId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddProblem([FromBody] AddProblemRequestDTO problemDto)
        {
            var response = await _problemService.AddProblem(problemDto);
            return Ok(response);
        }

        [HttpPut("{problemId}")]
        public async Task<IActionResult> UpdateProblem(Guid problemId, [FromBody] UpdateProblemRequestDTO problemDto)
        {
            var response = await _problemService.UpdateProblem(problemId, problemDto);
            return Ok(response);
        }
    }
}

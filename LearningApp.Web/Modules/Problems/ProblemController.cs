using LearningApp.Application.DataTransferObjects.ProblemDTO;
using LearningApp.Web.Modules.Common;
using Microsoft.AspNetCore.Mvc;

namespace LearningApp.Web.Modules.Problems
{
    [Route("api/v1")]
    public class ProblemController : BaseController
    {
        private readonly IProblemService _problemService;
        public ProblemController(IProblemService problemService)
        {
            _problemService = problemService;
        }

        [HttpGet("problems")]
        public async Task<IActionResult> GetProblems()
        {
            var response = await _problemService.GetAllProblems();
            return Ok(response);
        }

        [HttpGet("problems/{problemId}")]
        public async Task<IActionResult> GetProblemById(Guid problemId)
        {
            var response = await _problemService.GetProblemById(problemId);
            return Ok(response);
        }

        [HttpPost("problems")]
        public async Task<IActionResult> AddProblem([FromBody] AddProblemRequestDTO problemDto)
        {
            var response = await _problemService.AddProblem(problemDto);
            return Ok(response);
        }

        [HttpPut("problems/{problemId}")]
        public async Task<IActionResult> UpdateProblem(Guid problemId, [FromBody] UpdateProblemRequestDTO problemDto)
        {
            var response = await _problemService.UpdateProblem(problemId, problemDto);
            return Ok(response);
        }

        [HttpDelete("problems/{problemId}")]
        public async Task<IActionResult> DeleteProblem(Guid problemId)
        {
            var response = await _problemService.DeleteProblem(problemId);
            return Ok(response);
        }



        // below here starts problems for students
        [HttpGet("lessons/{lessonId}/problems")]
        public async Task<IActionResult> GetProblemsByTopicAndLesson(Guid lessonId)
        {
            var response = await _problemService.GetProblemsByLessonId(lessonId);
            return Ok(response);
        }
    }
}

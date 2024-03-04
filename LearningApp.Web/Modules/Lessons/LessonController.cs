using LearningApp.Application.DataTransferObjects.LessonDTO;
using LearningApp.Web.Modules.Common;
using LearningApp.Web.Modules.Problems;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningApp.Web.Modules.Lessons
{
    [Route("api/v1")]
    public class LessonController : BaseController
    {
        private readonly ILessonService _lessonService;
        private readonly IProblemService _problemService;
        public LessonController(ILessonService lessonService, IProblemService problemService) 
        {
            _lessonService = lessonService;
            _problemService = problemService;
        }

        //[Authorize(Roles = "AD")]
        [HttpGet("lessons")]
        public async Task<IActionResult> GetAllLessons()
        {
            return Ok(await _lessonService.GetAllLessons());
        }

        [Authorize(Roles = "AD, ST, TR")]
        [HttpGet("{lessonId}/problems")]
        public async Task<IActionResult> GetProblemsByLessonId(Guid lessonId)
        {
            var response = await _problemService.GetProblemsByLessonId(lessonId);
            return Ok(response);
        }

        //[Authorize(Roles = "AD, ST, TR")]
        [HttpGet("lessons/{id}")]
        public async Task<IActionResult> GetLessonById(Guid id)
        {
            return Ok(await _lessonService.GetLessonById(id));
        }

        //[Authorize(Roles = "AD, TR")]
        [HttpPost("lessons")]
        public async Task<IActionResult> CreateLesson([FromBody] LessonRequestDTO request)
        {
            return Ok(await _lessonService.CreateLesson(request));
        }

        //[Authorize(Roles = "AD, TR")]
        [HttpPut("lessons/{lessonId}")]
        public async Task<IActionResult> UpdateLesson(Guid lessonId, [FromBody] LessonRequestDTO request)
        {
            return Ok(await _lessonService.UpdateLesson(lessonId, request));
        }

        //[Authorize(Roles = "AD, TR")]
        [HttpDelete("lessons/{lessonId}")]
        public async Task<IActionResult> DeleteLesson(Guid lessonId)
        {
            return Ok(await _lessonService.DeleteLesson(lessonId));
        }
    }
}

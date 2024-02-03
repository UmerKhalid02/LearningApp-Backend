using LearningApp.Application.DataTransferObjects.LessonDTO;
using LearningApp.Web.Modules.Common;
using Microsoft.AspNetCore.Mvc;

namespace LearningApp.Web.Modules.Lessons
{
    [Route("api/v1")]
    public class LessonController : BaseController
    {
        private readonly ILessonService _lessonService;
        public LessonController(ILessonService lessonService) 
        {
            _lessonService = lessonService;
        }

        [HttpGet("lessons")]
        public async Task<IActionResult> GetAllLessons()
        {
            return Ok(await _lessonService.GetAllLessons());
        }

        [HttpGet("topics/{topicId}/lessons")]
        public async Task<IActionResult> GetAllLessonsByTopicId(Guid topicId)
        {
            return Ok(await _lessonService.GetAllLessonsByTopicId(topicId));
        }

        [HttpGet("lessons/{id}")]
        public async Task<IActionResult> GetLessonById(Guid id)
        {
            return Ok(await _lessonService.GetLessonById(id));
        }

        [HttpPost("lessons")]
        public async Task<IActionResult> CreateLesson([FromBody] LessonRequestDTO request)
        {
            return Ok(await _lessonService.CreateLesson(request));
        }

        [HttpPut("lessons/{lessonId}")]
        public async Task<IActionResult> UpdateLesson(Guid lessonId, [FromBody] LessonRequestDTO request)
        {
            return Ok(await _lessonService.UpdateLesson(lessonId, request));
        }

        [HttpDelete("lessons/{lessonId}")]
        public async Task<IActionResult> DeleteLesson(Guid lessonId)
        {
            return Ok(await _lessonService.DeleteLesson(lessonId));
        }
    }
}

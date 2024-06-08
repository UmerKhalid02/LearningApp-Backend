using LearningApp.Application.DataTransferObjects.TopicDTO;
using LearningApp.Web.Modules.Common;
using LearningApp.Web.Modules.Lessons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningApp.Web.Modules.Topics
{
    [Route("api/v1")]
    public class TopicController : BaseController
    {
        private readonly ITopicService _topicService;
        private readonly ILessonService _lessonService;
        public TopicController(ITopicService topicService, ILessonService lessonService)
        {
            _topicService = topicService;
            _lessonService = lessonService;
        }

        [Authorize(Roles = "AD, ST, TR")]
        [HttpGet("topics")]
        public async Task<IActionResult> GetAllTopics()
        {
            var userId = this.GetUserId();
            var response = await _topicService.GetAllTopics(userId);
            return Ok(response);
        }

        [Authorize(Roles = "AD, ST, TR")]
        [HttpGet("topics/{topicId}")]
        public async Task<IActionResult> GetTopicById(Guid topicId)
        {
            var userId = this.GetUserId();
            var response = await _topicService.GetTopicById(userId, topicId);
            return Ok(response);
        }

        [Authorize(Roles = "AD, ST, TR")]
        [HttpGet("topics/{topicId}/lessons")]
        public async Task<IActionResult> GetAllLessonsByTopicId(Guid topicId)
        {
            return Ok(await _lessonService.GetAllLessonsByTopicId(topicId));
        }

        [Authorize(Roles = "AD, TR")]
        [HttpPost("topics")]
        public async Task<IActionResult> CreateTopic([FromBody] TopicRequestDTO request)
        {
            var userId = this.GetUserId();
            var response = await _topicService.CreateTopic(request, userId);
            return Ok(response);
        }

        [Authorize(Roles = "AD, TR")]
        [HttpPut("topics/{topicId}")]
        public async Task<IActionResult> UpdateTopic(Guid topicId, [FromBody] TopicRequestDTO request)
        {
            var userId = this.GetUserId();
            var response = await _topicService.UpdateTopic(topicId, request, userId);
            return Ok(response);
        }

        [Authorize(Roles = "AD, TR")]
        [HttpDelete("topics/{topicId}")]
        public async Task<IActionResult> DeleteTopic(Guid topicId)
        {
            var userId = this.GetUserId();
            var response = await _topicService.DeleteTopic(topicId, userId);
            return Ok(response);
        }

        // topics created by specific user/teacher 
        [Authorize(Roles = "AD, TR")]
        [HttpGet("topics/users/{userId}")]
        public async Task<IActionResult> GetAllUserCreatedTopics(Guid userId)
        {
            var response = await _topicService.GetAllUserCreatedTopics(userId);
            return Ok(response);
        }

        [Authorize(Roles = "AD, TR")]
        [HttpGet("topics/{topicId}/lessons/users/{userId}")]
        public async Task<IActionResult> GetAllUserCreatedLessonsByTopicId(Guid userId, Guid topicId)
        {
            var response = await _topicService.GetAllUserCreatedLessonsByTopicId(userId, topicId);
            return Ok(response);
        }
    }
}

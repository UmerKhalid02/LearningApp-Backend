using LearningApp.Application.DataTransferObjects.TopicDTO;
using LearningApp.Web.Modules.Common;
using LearningApp.Web.Modules.Lessons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningApp.Web.Modules.Topics
{
    [Route("api/v1/topics")]
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
        [HttpGet]
        public async Task<IActionResult> GetAllTopics()
        {
            var response = await _topicService.GetAllTopics();
            return Ok(response);
        }

        [Authorize(Roles = "AD, ST, TR")]
        [HttpGet("{topicId}")]
        public async Task<IActionResult> GetTopicById(Guid topicId)
        {
            var response = await _topicService.GetTopicById(topicId);
            return Ok(response);
        }

        [Authorize(Roles = "AD, ST, TR")]
        [HttpGet("{topicId}/lessons")]
        public async Task<IActionResult> GetAllLessonsByTopicId(Guid topicId)
        {
            return Ok(await _lessonService.GetAllLessonsByTopicId(topicId));
        }

        [Authorize(Roles = "AD, TR")]
        [HttpPost]
        public async Task<IActionResult> CreateTopic([FromBody] TopicRequestDTO request)
        {
            var response = await _topicService.CreateTopic(request);
            return Ok(response);
        }

        [Authorize(Roles = "AD, TR")]
        [HttpPut("{topicId}")]
        public async Task<IActionResult> UpdateTopic(Guid topicId, [FromBody] TopicRequestDTO request)
        {
            var response = await _topicService.UpdateTopic(topicId, request);
            return Ok(response);
        }

        [Authorize(Roles = "AD, TR")]
        [HttpDelete("{topicId}")]
        public async Task<IActionResult> DeleteTopic(Guid topicId)
        {
            var response = await _topicService.DeleteTopic(topicId);
            return Ok(response);
        }
    }
}

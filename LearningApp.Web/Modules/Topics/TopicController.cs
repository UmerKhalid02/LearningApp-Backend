using LearningApp.Application.DataTransferObjects.TopicDTO;
using LearningApp.Web.Modules.Common;
using Microsoft.AspNetCore.Mvc;

namespace LearningApp.Web.Modules.Topics
{
    [Route("api/v1/topics")]
    public class TopicController : BaseController
    {
        private readonly ITopicService _topicService;
        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTopics()
        {
            var response = await _topicService.GetAllTopics();
            return Ok(response);
        }

        [HttpGet("{topicId}")]
        public async Task<IActionResult> GetTopicById(Guid topicId)
        {
            var response = await _topicService.GetTopicById(topicId);
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTopic([FromBody] TopicRequestDTO request)
        {
            var response = await _topicService.CreateTopic(request);
            return Ok(response);
        }


        [HttpPut("{topicId}")]
        public async Task<IActionResult> UpdateTopic(Guid topicId, [FromBody] TopicRequestDTO request)
        {
            var response = await _topicService.UpdateTopic(topicId, request);
            return Ok(response);
        }
        
        [HttpDelete("{topicId}")]
        public async Task<IActionResult> DeleteTopic(Guid topicId)
        {
            var response = await _topicService.DeleteTopic(topicId);
            return Ok(response);
        }
    }
}

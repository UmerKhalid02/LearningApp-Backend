using LearningApp.Application.DataTransferObjects.TopicDTO;
using LearningApp.Application.Wrappers;

namespace LearningApp.Web.Modules.Topics
{
    public interface ITopicService
    {
        public Task<Response<List<TopicResponseDTO>>> GetAllTopics();
        public Task<Response<TopicResponseDTO>> GetTopicById(Guid topicId);
        public Task<Response<TopicResponseDTO>> CreateTopic(TopicRequestDTO request);
        public Task<Response<TopicResponseDTO>> UpdateTopic(Guid topicId, TopicRequestDTO request);
        public Task<Response<bool>> DeleteTopic(Guid topicId);
    }
}

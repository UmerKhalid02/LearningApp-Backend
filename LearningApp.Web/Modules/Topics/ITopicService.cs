using LearningApp.Application.DataTransferObjects.TopicDTO;
using LearningApp.Application.Wrappers;

namespace LearningApp.Web.Modules.Topics
{
    public interface ITopicService
    {
        public Task<Response<List<TopicResponseDTO>>> GetAllTopics();
        public Task<Response<List<TopicResponseDTO>>> GetAllTopics(Guid userId);
        public Task<Response<TopicResponseDTO>> GetTopicById(Guid topicId);
        public Task<Response<TopicResponseDTO>> CreateTopic(TopicRequestDTO request, Guid userId);
        public Task<Response<TopicResponseDTO>> UpdateTopic(Guid topicId, TopicRequestDTO request, Guid userId);
        public Task<Response<bool>> DeleteTopic(Guid topicId, Guid userId);
    }
}

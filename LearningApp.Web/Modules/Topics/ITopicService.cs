using LearningApp.Application.DataTransferObjects.LessonDTO;
using LearningApp.Application.DataTransferObjects.TopicDTO;
using LearningApp.Application.Wrappers;

namespace LearningApp.Web.Modules.Topics
{
    public interface ITopicService
    {
        public Task<Response<List<TopicResponseDTO>>> GetAllTopics(Guid userId);
        public Task<Response<List<TopicResponseDTO>>> GetAllUserCreatedTopics(Guid userId);
        public Task<Response<List<LessonResponseDTO>>> GetAllUserCreatedLessonsByTopicId(Guid userId, Guid topicId);
        public Task<Response<TopicResponseDTO>> GetTopicById(Guid userId, Guid topicId);
        public Task<Response<TopicResponseDTO>> CreateTopic(TopicRequestDTO request, Guid userId);
        public Task<Response<TopicResponseDTO>> UpdateTopic(Guid topicId, TopicRequestDTO request, Guid userId);
        public Task<Response<bool>> DeleteTopic(Guid topicId, Guid userId);
    }
}

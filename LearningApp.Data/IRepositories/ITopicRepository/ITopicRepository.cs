using LearningApp.Data.Entities.ProblemEntity;

namespace LearningApp.Data.IRepositories.ITopicRepository
{
    public interface ITopicRepository
    {
        public Task<List<Topic>> GetAllTopics();
        public Task<List<Topic>> GetAllTopics(Guid userId);
        public Task<List<Lesson>> GetAllUserCreatedLessonsByTopicId(Guid userId, Guid topicId);
        public Task<Topic> GetTopicById(Guid topicId);
        public Task<Topic> GetTopicByName(string topicName);
        public Task<Topic> CreateTopic(Topic topic);
        public Task<bool> DeleteTopic(Topic topic);
        public Task SaveChanges();
    }
}

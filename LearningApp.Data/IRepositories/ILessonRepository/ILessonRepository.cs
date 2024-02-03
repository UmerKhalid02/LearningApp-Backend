using LearningApp.Data.Entities.ProblemEntity;

namespace LearningApp.Data.IRepositories.ILessonRepository
{
    public interface ILessonRepository
    {
        public Task<List<Lesson>> GetAllLessons();
        public Task<List<Lesson>> GetAllLessonsByTopicId(Guid topicId);
        public Task<Lesson> GetLessonById(Guid lessonId);
        public Task<Lesson> GetLessonByLessonNumber(int lessonNumber, Guid topicId);
        public Task<Lesson> AddLesson(Lesson lesson);
        public Task SaveChanges();
    }
}

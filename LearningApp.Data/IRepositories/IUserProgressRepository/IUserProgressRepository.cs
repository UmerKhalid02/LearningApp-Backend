using LearningApp.Data.Entities.UserEntity;

namespace LearningApp.Data.IRepositories.IUserProgressRepository
{
    public interface IUserProgressRepository
    {
        Task<UserProgress> AddUserProgress(UserProgress userProgress);
        Task<UserProgress?> GetUserProgressForALesson(Guid userId, Guid lessonId);
        Task<int> CompletedLessonsCount(Guid userId, Guid topicId);
    }
}

using LearningApp.Data.Entities.ProblemEntity;
using LearningApp.Data.Entities.UserEntity;

namespace LearningApp.Data.IRepositories.IRecentUserLessonsRepository
{
    public interface IRecentUserLessonsRepository
    {
        Task<List<RecentUserLessons>> GetAllRecentUserLessons(Guid userId);
        Task<RecentUserLessons> AddLessonInRecentLessons(RecentUserLessons recentUserLesson);
    }
}

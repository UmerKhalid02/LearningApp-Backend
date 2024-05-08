using LearningApp.Data.Entities.UserEntity;
using LearningApp.Data.IRepositories.IUserProgressRepository;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Data.Repositories.UserProgressRepository
{
    public class UserProgressRepository : IUserProgressRepository
    {
        private readonly EFDataContext _context;

        public UserProgressRepository(EFDataContext context)
        {
            _context = context;
        }

        public async Task<UserProgress> AddUserProgress(UserProgress userProgress)
        {
            await _context.UserProgress.AddAsync(userProgress);
            return userProgress;
        }

        public async Task<UserProgress?> GetUserProgressForALesson(Guid userId, Guid lessonId)
        {
            var userProgress = await _context.UserProgress.FirstOrDefaultAsync(x => x.UserId == userId && x.LessonId == lessonId && x.IsActive);
            return userProgress;
        }

        public async Task<int> CompletedLessonsCount(Guid userId, Guid topicId)
        {
            int lessonsCount = await _context.UserProgress.CountAsync(x => x.UserId == userId && x.TopicId == topicId && x.IsActive);
            return lessonsCount;
        }
    }
}

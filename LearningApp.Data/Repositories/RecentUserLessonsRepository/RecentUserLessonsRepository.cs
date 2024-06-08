using LearningApp.Data.Entities.UserEntity;
using LearningApp.Data.IRepositories.IRecentUserLessonsRepository;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Data.Repositories.RecentUserLessonsRepository
{
    public class RecentUserLessonsRepository : IRecentUserLessonsRepository
    {
        private readonly EFDataContext _context;
        public RecentUserLessonsRepository(EFDataContext context)
        {
            _context = context;
        }

        public async Task<List<RecentUserLessons>> GetAllRecentUserLessons(Guid userId)
        { 
            var recentUserLessons = await _context.RecentUserLessons
                .Include(x => x.Lesson)
                .Where(x => x.UserId == userId && x.IsActive).ToListAsync();
            return recentUserLessons;
        }

        public async Task<RecentUserLessons> AddLessonInRecentLessons(RecentUserLessons recentUserLesson)
        { 
            await _context.RecentUserLessons.AddAsync(recentUserLesson);
            await _context.SaveChangesAsync();
            return recentUserLesson;
        }

    }
}

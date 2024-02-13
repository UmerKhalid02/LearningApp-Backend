using LearningApp.Data.Entities.ProblemEntity;
using LearningApp.Data.IRepositories.ILessonRepository;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Data.Repositories.LessonRepository
{
    public class LessonRepository : ILessonRepository
    {
        private readonly EFDataContext _context;

        public LessonRepository(EFDataContext context)
        {
            _context = context;
        }

        public async Task<List<Lesson>> GetAllLessons()
        {
            var lessons = await _context.Lessons
                .Include(x => x.Topic)
                .Include(x => x.Problems.Where(p => p.IsActive)).ThenInclude(p => p.Choices.Where(c => c.IsActive))
                .Where(x => x.IsActive).ToListAsync();

            return lessons;
        }

        public async Task<List<Lesson>> GetAllLessonsByTopicId(Guid topicId)
        {
            var lessons = await _context.Lessons
                .Include(x => x.Topic)
                .Include(x => x.Problems.Where(p => p.IsActive)).ThenInclude(p => p.Choices.Where(c => c.IsActive))
                .Where(x => x.IsActive && x.TopicId == topicId).ToListAsync();

            return lessons;
        }

        public async Task<Lesson> GetLessonById(Guid lessonId)
        {
            var lesson = await _context.Lessons
                .Include(x => x.Topic)
                .Include(x => x.Problems.Where(p => p.IsActive)).ThenInclude(p => p.Choices.Where(c => c.IsActive))
                .FirstOrDefaultAsync(x => x.LessonId == lessonId && x.IsActive);

            return lesson;
        }

        public async Task<Lesson> GetLessonByLessonNumber(int lessonNumber, Guid topicId)
        {
            var lesson = await _context.Lessons.FirstOrDefaultAsync(x => x.LessonNumber == lessonNumber && x.TopicId == topicId && x.IsActive);
            return lesson;
        }

        public async Task<Lesson> AddLesson(Lesson lesson)
        {
            await _context.Lessons.AddAsync(lesson);
            return lesson;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}

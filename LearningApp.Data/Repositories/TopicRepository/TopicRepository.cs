using LearningApp.Data.Entities.ProblemEntity;
using LearningApp.Data.IRepositories.ITopicRepository;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Data.Repositories.TopicRepository
{
    public class TopicRepository : ITopicRepository
    {
        private readonly EFDataContext _context;
        public TopicRepository(EFDataContext context)
        {
            _context = context;
        }

        public async Task<List<Topic>> GetAllTopics(Guid userId)
        {
            var topics = await _context.Topics
                .Include(x => x.Lessons.Where(l => l.IsActive))
                .Include(x => x.UserProgresses.Where(u => u.UserId == userId && u.LessonId != null && u.IsActive))
                .Where(x => x.IsActive).ToListAsync();
            return topics;
        }

        public async Task<List<Topic>> GetAllUserCreatedTopics(Guid userId)
        {
            var topics = await _context.Topics
                .Include(x => x.Lessons.Where(l => l.IsActive))
                .Where(x => x.IsActive && x.CreatedBy == userId).ToListAsync();
            return topics;
        }

        public async Task<Topic> GetTopicById(Guid topicId)
        {
            var topic = await _context.Topics
                .Include(x => x.Lessons.Where(l => l.IsActive))
                .FirstOrDefaultAsync(x => x.TopicId == topicId && x.IsActive);
            return topic;
        }

        public async Task<Topic> GetTopicById(Guid userId, Guid topicId)
        {
            var topic = await _context.Topics
                .Include(x => x.Lessons.Where(l => l.IsActive))
                .Include(x => x.UserProgresses.Where(u => u.TopicId == topicId && u.LessonId != null && u.UserId == userId && u.IsActive))
                .FirstOrDefaultAsync(x => x.TopicId == topicId && x.IsActive);
            return topic;
        }

        public async Task<Topic> GetTopicByName(string topicName)
        {
            var topic = await _context.Topics.Where(x => x.TopicName == topicName && x.IsActive).FirstOrDefaultAsync();
            return topic;
        }

        public async Task<Topic> CreateTopic(Topic topic)
        {
            await _context.Topics.AddAsync(topic);
            return topic;
        }


        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteTopic(Topic topic)
        {
            _context.Topics.Remove(topic);
            return true;
        }

        public async Task<List<Lesson>> GetAllUserCreatedLessonsByTopicId(Guid userId, Guid topicId)
        {
            var lessons = await _context.Lessons
                .Include(x => x.Topic)
                .Include(x => x.Problems.Where(p => p.IsActive)).ThenInclude(p => p.Choices.Where(c => c.IsActive))
                .Where(x => x.IsActive && x.CreatedBy == userId && x.TopicId == topicId).ToListAsync();
            return lessons;
        }

        public Task<Topic?> GetTeacherTopicById(Guid userId, Guid topicId)
        {
            var topic = _context.Topics.FirstOrDefaultAsync(x => x.TopicId == topicId && x.CreatedBy == userId && x.IsActive);
            return topic;
        }
    }
}

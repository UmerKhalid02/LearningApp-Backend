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

        public async Task<List<Topic>> GetAllTopics()
        {
            var topics = await _context.Topics.Where(x => x.IsActive).ToListAsync();
            return topics;
        }

        public async Task<Topic> GetTopicById(Guid topicId)
        {
            var topic = await _context.Topics.FirstOrDefaultAsync(x => x.TopicId == topicId && x.IsActive);
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

        
    }
}

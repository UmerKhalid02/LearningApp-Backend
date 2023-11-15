using LearningApp.Data.Entities.ProblemEntity;
using LearningApp.Data.IRepositories.IProblemRepository;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Data.Repositories.ProblemRepository
{
    public class ProblemRepository : IProblemRepository
    {
        private readonly EFDataContext _context;
        public ProblemRepository(EFDataContext context)
        {
            _context = context;
        }

        public async Task<List<Problem>> GetAllProblems()
        {
            var query = await _context.Problems
                .Include(x => x.Topic)
                .Include(x => x.Choices.Where(c => c.IsActive))
                .Where(x => x.IsActive).ToListAsync();

            return query;
        }

        public async Task<Problem> GetProblemById(Guid problemId)
        {
            var query = await _context.Problems
                .Include(x => x.Topic)
                .Include(x => x.Choices.Where(c => c.IsActive))
                .FirstOrDefaultAsync(x => x.ProblemId == problemId && x.IsActive);

            return query;
        }

        public async Task<Problem> AddProblem(Problem problem)
        {
            await _context.Problems.AddAsync(problem);
            return problem;
        }

        public Problem UpdateProblem(Problem problem)
        {
            _context.Problems.Update(problem);
            return problem;
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task<Topic?> GetTopicById(Guid topicId) =>
            await _context.Topics.FirstOrDefaultAsync(x => x.TopicId == topicId && x.IsActive);

        public async Task<Choice?> GetChoiceByIdForProblem(Guid choiceId, Guid problemId) => 
            await _context.Choices.FirstOrDefaultAsync(x => x.ChoiceId == choiceId && x.ProblemId == problemId && x.IsActive);

    }
}

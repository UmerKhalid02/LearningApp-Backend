using LearningApp.Data.Entities.ProblemEntity;

namespace LearningApp.Data.IRepositories.IProblemRepository
{
    public interface IProblemRepository
    {
        public Task<List<Problem>> GetAllProblems();
        public Task<Problem> GetProblemById(Guid problemId);
        public Task<Problem> AddProblem(Problem problem);
        public Problem UpdateProblem(Problem problem);
        public Task SaveChangesAsync();
        public Task<Topic?> GetTopicById(Guid topicId);
        public Task<Choice?> GetChoiceByIdForProblem(Guid choiceId, Guid problemId);
    }
}

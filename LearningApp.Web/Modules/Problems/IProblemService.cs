using LearningApp.Application.DataTransferObjects.ProblemDTO;
using LearningApp.Application.Wrappers;

namespace LearningApp.Web.Modules.Problems
{
    public interface IProblemService
    {
        public Task<Response<List<ProblemResponseDTO>>> GetAllProblems(); // later to be converted to pagination response
        public Task<Response<List<ProblemResponseDTO>>> GetAllProblems(Guid userId);
        public Task<Response<ProblemResponseDTO>> GetProblemById(Guid problemId);

        public Task<Response<ProblemResponseDTO>> AddProblem(AddProblemRequestDTO problemDto, Guid creatorId); // can change return type since it returns null in payload 
        public Task<Response<ProblemResponseDTO>> UpdateProblem(Guid problemId, UpdateProblemRequestDTO problemDto, Guid userId);
        public Task<Response<bool>> DeleteProblem(Guid problemId, Guid userId);
        public Task<Response<List<ProblemResponseDTO>>> GetProblemsByLessonId(Guid lessonId);
    }
}

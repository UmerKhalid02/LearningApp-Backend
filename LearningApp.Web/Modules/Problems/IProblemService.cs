using LearningApp.Application.DataTransferObjects.ProblemDTO;
using LearningApp.Application.Wrappers;

namespace LearningApp.Web.Modules.Problems
{
    public interface IProblemService
    {
        public Task<Response<List<ProblemResponseDTO>>> GetAllProblems(); // later to be converted to pagination response
        public Task<Response<ProblemResponseDTO>> GetProblemById(Guid problemId);

        public Task<Response<ProblemResponseDTO>> AddProblem(AddProblemRequestDTO problemDto); // can change return type since it returns null in payload 
    }
}

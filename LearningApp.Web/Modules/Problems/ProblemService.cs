using AutoMapper;
using LearningApp.Application.DataTransferObjects.ProblemDTO;
using LearningApp.Application.Enums;
using LearningApp.Application.Wrappers;
using LearningApp.Data.Entities.ProblemEntity;
using LearningApp.Data.IRepositories.IProblemRepository;

namespace LearningApp.Web.Modules.Problems
{
    public class ProblemService : IProblemService
    {
        private readonly IProblemRepository _problemRepository;
        private readonly IMapper _mapper;
        public ProblemService(IProblemRepository problemRepository, IMapper mapper)
        {
            _problemRepository = problemRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<ProblemResponseDTO>>> GetAllProblems()
        {
            // convert to pagination response
            var problems = await _problemRepository.GetAllProblems();
            var response = _mapper.Map<List<ProblemResponseDTO>>(problems);

            return new Response<List<ProblemResponseDTO>>(true, response, GeneralMessages.RecordFetched);
        }

        public async Task<Response<ProblemResponseDTO>> GetProblemById(Guid problemId)
        {
            var problem = await _problemRepository.GetProblemById(problemId);

            if (problem == null)
                throw new KeyNotFoundException(GeneralMessages.InvalidProblemId);

            var response = _mapper.Map<ProblemResponseDTO>(problem);

            return new Response<ProblemResponseDTO>(true, response, GeneralMessages.RecordFetched);
        }

        public async Task<Response<ProblemResponseDTO>> AddProblem(AddProblemRequestDTO problemDto)
        {
            // check if topic exists
            var topic = await _problemRepository.GetTopicById(problemDto.TopicId);
            if (topic == null)
                throw new KeyNotFoundException(GeneralMessages.InvalidTopicId);
            

            // map dto to entity
            var problem = _mapper.Map<Problem>(problemDto);
            problem.IsActive = true;
            problem.CreatedAt = DateTime.UtcNow;

            await _problemRepository.AddProblem(problem);
            await _problemRepository.SaveChangesAsync();

            return new Response<ProblemResponseDTO>(true, null, GeneralMessages.RecordAdded);
        }

        
    }
}

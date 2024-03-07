using AutoMapper;
using LearningApp.Application.DataTransferObjects.ProblemDTO;
using LearningApp.Application.Enums;
using LearningApp.Application.Exceptions;
using LearningApp.Application.Wrappers;
using LearningApp.Data.Entities.ProblemEntity;
using LearningApp.Data.IRepositories.ILessonRepository;
using LearningApp.Data.IRepositories.IProblemRepository;

namespace LearningApp.Web.Modules.Problems
{
    public class ProblemService : IProblemService
    {
        #region Private Methods

        private readonly IProblemRepository _problemRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;

        private bool DistinctChoicesKeys(List<UpdateChoiceRequestDTO> choiceDTO)
        {
            var distinct = choiceDTO.Select(c => c.ChoiceId).Distinct().Count() == choiceDTO.Count();
            return distinct;
        }
        private void RemoveChoicesFromProblem(Problem problem)
        {
            foreach (var choice in problem.Choices)
            {
                choice.IsActive = false;
                choice.UpdatedAt = DateTime.UtcNow;
                choice.DeletedAt = DateTime.UtcNow;
            }
        }

        #endregion


        #region Public Methods
        public ProblemService(IProblemRepository problemRepository, ILessonRepository lessonRepository, IMapper mapper)
        {
            _problemRepository = problemRepository;
            _lessonRepository = lessonRepository;
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

        public async Task<Response<ProblemResponseDTO>> AddProblem(AddProblemRequestDTO problemDto, Guid creatorId)
        {
            // check if lesson exists
            var lesson = await _lessonRepository.GetLessonById(problemDto.LessonId);
            if (lesson == null)
                throw new KeyNotFoundException(GeneralMessages.InvalidLessonId);

            // check problem type
            if(EProblemTypeExtensions.ProblemTypeIsInvalid(problemDto.Type))
                throw new BadRequestException(GeneralMessages.InvalidProblemType);

            // check if type is MCQ or TF, then choices must be provided
            if ((string.Equals(problemDto.Type, EProblemType.MCQ.GetProblemTypeStringValue(), StringComparison.OrdinalIgnoreCase)
                || string.Equals(problemDto.Type, EProblemType.TF.GetProblemTypeStringValue(), StringComparison.OrdinalIgnoreCase))
                && (problemDto.Choices == null || problemDto.Choices.Count == 0))
            {
                throw new BadRequestException(GeneralMessages.ProvideChoicesError);
            }

            // map dto to entity
            var problem = _mapper.Map<Problem>(problemDto);
            problem.IsActive = true;
            problem.CreatedAt = DateTime.UtcNow;
            problem.CreatedBy = creatorId;

            if (problem.Choices != null && problem.Choices.Count > 0) {

                if (string.Equals(problemDto.Type, EProblemType.MCQ.GetProblemTypeStringValue(), StringComparison.OrdinalIgnoreCase) && problem.Choices.Count != 4) {
                    throw new BadRequestException(GeneralMessages.InvalidChoiceCountMCQ);
                }
                else if (string.Equals(problemDto.Type, EProblemType.TF.GetProblemTypeStringValue(), StringComparison.OrdinalIgnoreCase) && problem.Choices.Count != 2) {
                    throw new BadRequestException(GeneralMessages.InvalidChoiceCountTF);
                }

                foreach (var choice in problem.Choices)
                {
                    choice.IsActive = true;
                    choice.CreatedAt = DateTime.UtcNow;
                    choice.CreatedBy = creatorId;
                }
            }

            await _problemRepository.AddProblem(problem);
            await _problemRepository.SaveChangesAsync();

            return new Response<ProblemResponseDTO>(true, null, GeneralMessages.RecordAdded);
        }

        // TODO: check if problem type is other than mcq/tf, then choices must not be provided
        // TODO: mapping is creating problems

        public async Task<Response<ProblemResponseDTO>> UpdateProblem(Guid problemId, UpdateProblemRequestDTO problemDto, Guid userId)
        {
            // check if problem exists
            var problem = await _problemRepository.GetProblemById(problemId);
            if(problem == null)
                throw new KeyNotFoundException(GeneralMessages.InvalidProblemId);

            // check if lesson exists
            var lesson = await _lessonRepository.GetLessonById(problemDto.LessonId);
            if (lesson == null)
                throw new KeyNotFoundException(GeneralMessages.InvalidLessonId);

            // check problem type
            if (EProblemTypeExtensions.ProblemTypeIsInvalid(problemDto.Type))
                throw new BadRequestException(GeneralMessages.InvalidProblemType);

            // check if type is MCQ or TF, then choices must be provided
            if ((string.Equals(problemDto.Type, EProblemType.MCQ.GetProblemTypeStringValue(), StringComparison.OrdinalIgnoreCase) 
                || string.Equals(problemDto.Type, EProblemType.TF.GetProblemTypeStringValue(), StringComparison.OrdinalIgnoreCase)) 
                && (problemDto.Choices == null || problemDto.Choices.Count == 0)) 
            { 
                throw new BadRequestException(GeneralMessages.ProvideChoicesError);
            }

            // check if problemDTO type is MCQ or TF, then choices count must be 4 or 2 respectively
            if (problemDto.Choices != null && problemDto.Choices.Count > 0)
            {
                if (string.Equals(problemDto.Type, EProblemType.MCQ.GetProblemTypeStringValue(), StringComparison.OrdinalIgnoreCase) && problemDto.Choices.Count != 4)
                    throw new BadRequestException(GeneralMessages.InvalidChoiceCountMCQ);
                
                else if (string.Equals(problemDto.Type, EProblemType.TF.GetProblemTypeStringValue(), StringComparison.OrdinalIgnoreCase) && problemDto.Choices.Count != 2)
                    throw new BadRequestException(GeneralMessages.InvalidChoiceCountTF);
            }

            // check if problem already contains choices and updateDTO also contains, must update them (updateDTO must have ChoiceID)
            //      subcheck: all choice ids must be distinct 
            if ((problem.Choices != null && problem.Choices.Count > 0) && (problemDto.Choices != null && problemDto.Choices.Count > 0))
            {
                // check if all choice ids are distinct
                if (!DistinctChoicesKeys(problemDto.Choices))
                    throw new BadRequestException(GeneralMessages.InvalidChoiceIds);

                // if choices count is same, then update existing choices
                if (problem.Choices.Count == problemDto.Choices.Count)
                {
                    _mapper.Map(problemDto, problem);
                    List<Choice> choices = new List<Choice>();
                    foreach (var choice in problem.Choices)
                    {
                        if (choice.ChoiceId != null || choice.ChoiceId != Guid.Empty)
                        {
                            var choiceEntity = await _problemRepository.GetChoiceByIdForProblem((Guid)choice.ChoiceId, problemId);
                            if (choiceEntity == null)
                                throw new KeyNotFoundException(GeneralMessages.InvalidChoiceId);

                            choiceEntity.ChoiceText = choice.ChoiceText;
                            choiceEntity.UpdatedAt = DateTime.UtcNow;
                            choice.UpdatedBy = userId;
                            choices.Add(choiceEntity);
                        }
                        else
                        {
                            throw new BadRequestException(GeneralMessages.ChoiceIdError);
                        }
                    }
                    problem.Choices = choices;
                }

                // if choices count is different, then remove all choices if they exist and add new ones
                else
                {
                    // remove choices
                    if (problem.Choices != null)
                        RemoveChoicesFromProblem(problem);

                    _mapper.Map(problemDto, problem);
                    foreach (var choice in problem.Choices)
                    {
                        choice.ChoiceId = Guid.NewGuid();
                        choice.IsActive = true;
                        choice.CreatedAt = DateTime.UtcNow;
                        choice.CreatedBy = userId;
                    }
                    await _problemRepository.AddChoicesForProblem(problem.Choices);
                }
            }

            else if (problem.Choices != null && problem.Choices.Count > 0)
            {
                // remove choices
                RemoveChoicesFromProblem(problem);
                _mapper.Map(problemDto, problem);
            }

            else if (problemDto.Choices != null && problemDto.Choices.Count > 0) 
            {
                _mapper.Map(problemDto, problem);
                foreach (var choice in problem.Choices)
                {
                    choice.ChoiceId = Guid.NewGuid();
                    choice.IsActive = true;
                    choice.CreatedAt = DateTime.UtcNow;
                    choice.CreatedBy = userId;
                }
                await _problemRepository.AddChoicesForProblem(problem.Choices);
            }

            else
            {
                _mapper.Map(problemDto, problem);
            }

            problem.UpdatedAt = DateTime.UtcNow;
            problem.UpdatedBy = userId;

            //_problemRepository.UpdateProblem(problem);
            await _problemRepository.SaveChangesAsync();

            return new Response<ProblemResponseDTO>(true, null, GeneralMessages.RecordUpdated);
        }

        public async Task<Response<bool>> DeleteProblem(Guid problemId, Guid userId)
        {
            var problem = await _problemRepository.GetProblemById(problemId);
            if(problem == null)
                throw new KeyNotFoundException(GeneralMessages.InvalidProblemId);

            problem.IsActive = false;
            problem.UpdatedAt = DateTime.UtcNow;
            problem.DeletedAt = DateTime.UtcNow;
            problem.DeletedBy = userId;

            // delete all choices
            if (problem.Choices != null && problem.Choices.Count > 0)
            {
                foreach (var choice in problem.Choices)
                {
                    choice.IsActive = false;
                    choice.UpdatedAt = DateTime.UtcNow;
                    choice.DeletedAt = DateTime.UtcNow;
                    choice.DeletedBy = userId;
                }
            }

            try
            {
                await _problemRepository.SaveChangesAsync();
                return new Response<bool>(true, true, GeneralMessages.RecordDeleted);
            } catch (Exception e) 
            {
                throw new InternalServerErrorException(e.Message);
            }
        }

        public async Task<Response<List<ProblemResponseDTO>>> GetProblemsByLessonId(Guid lessonId)
        {
            // check if lesson exists
            var lesson = await _lessonRepository.GetLessonById(lessonId);
            if (lesson == null)
                throw new KeyNotFoundException(GeneralMessages.InvalidTopicId);

            var problems = await _problemRepository.GetProblemsLessonId(lessonId);
            var problemResponse = _mapper.Map<List<ProblemResponseDTO>>(problems);

            return new Response<List<ProblemResponseDTO>>(true, problemResponse, GeneralMessages.RecordFetched);
        }
        #endregion
    }
}

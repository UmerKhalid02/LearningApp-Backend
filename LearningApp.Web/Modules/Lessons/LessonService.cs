using AutoMapper;
using LearningApp.Application.DataTransferObjects.LessonDTO;
using LearningApp.Application.Enums;
using LearningApp.Application.Exceptions;
using LearningApp.Application.Wrappers;
using LearningApp.Data.Entities.ProblemEntity;
using LearningApp.Data.IRepositories.ILessonRepository;
using LearningApp.Data.IRepositories.ITopicRepository;
using MediatR;

namespace LearningApp.Web.Modules.Lessons
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly IMapper _mapper;
        public LessonService(ILessonRepository lessonRepository, ITopicRepository topicRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _topicRepository = topicRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<LessonResponseDTO>>> GetAllLessons()
        {
            var lessons = await _lessonRepository.GetAllLessons();
            var response = _mapper.Map<List<LessonResponseDTO>>(lessons);
            return new Response<List<LessonResponseDTO>>(true, response, GeneralMessages.RecordFetched);
        }
        
        public async Task<Response<List<LessonResponseDTO>>> GetAllLessons(Guid userId)
        {
            var lessons = await _lessonRepository.GetAllLessons(userId);
            var response = _mapper.Map<List<LessonResponseDTO>>(lessons);
            return new Response<List<LessonResponseDTO>>(true, response, GeneralMessages.RecordFetched);
        }

        public async Task<Response<List<LessonResponseDTO>>> GetAllLessonsByTopicId(Guid topicId)
        {
            // check if that topic exists
            var topic = await _topicRepository.GetTopicById(topicId);
            if (topic == null) {
                throw new KeyNotFoundException(GeneralMessages.InvalidTopicId);
            }

            var lessons = await _lessonRepository.GetAllLessonsByTopicId(topicId);
            var response = _mapper.Map<List<LessonResponseDTO>>(lessons);
            return new Response<List<LessonResponseDTO>>(true, response, GeneralMessages.RecordFetched);
        }

        public async Task<Response<LessonResponseDTO>> GetLessonById(Guid id)
        {
            var lesson = await _lessonRepository.GetLessonById(id);

            if (lesson == null)
                throw new KeyNotFoundException(GeneralMessages.InvalidLessonId);

            var response = _mapper.Map<LessonResponseDTO>(lesson);

            return new Response<LessonResponseDTO>(true, response, GeneralMessages.RecordFetched);
        }

        public async Task<Response<LessonResponseDTO>> CreateLesson(LessonRequestDTO request, Guid userId)
        {
            // check if lesson topic with that id exists
            var topic = await _topicRepository.GetTopicById(request.TopicId);
            if (topic == null) {
                throw new KeyNotFoundException(GeneralMessages.InvalidTopicId);
            }

            // check if lesson with that lessonNumber exists
            var lesson = await _lessonRepository.GetLessonByLessonNumber(request.LessonNumber, request.TopicId);
            if (lesson != null) {
                throw new ConflictException(GeneralMessages.LessonNumberExists);
            }

            var newLesson = _mapper.Map<Lesson>(request);
            newLesson.IsActive = true;
            newLesson.CreatedAt = DateTime.UtcNow;
            newLesson.CreatedBy = userId;

            await _lessonRepository.AddLesson(newLesson);
            await _lessonRepository.SaveChanges();

            return new Response<LessonResponseDTO>(true, null, GeneralMessages.RecordAdded);
        }

        public async Task<Response<LessonResponseDTO>> UpdateLesson(Guid lessonId, LessonRequestDTO request, Guid userId)
        {
            // check if lesson exists
            var lesson = await _lessonRepository.GetLessonById(lessonId);
            if (lesson == null) {
                throw new KeyNotFoundException(GeneralMessages.InvalidLessonId);
            }

            // check if lesson topic with that id exists
            var topic = await _topicRepository.GetTopicById(request.TopicId);
            if (topic == null) {
                throw new KeyNotFoundException(GeneralMessages.InvalidTopicId);
            }

            // check if lesson with that lessonNumber exists
            var lessonWithLessonNumber = await _lessonRepository.GetLessonByLessonNumber(request.LessonNumber, request.TopicId);
            if (lessonWithLessonNumber != null) {
                throw new ConflictException(GeneralMessages.LessonNumberExists);
            }

            _mapper.Map(request, lesson);
            lesson.UpdatedAt = DateTime.UtcNow;
            lesson.UpdatedBy = userId;

            await _lessonRepository.SaveChanges();

            return new Response<LessonResponseDTO>(true, _mapper.Map<LessonResponseDTO>(lesson), GeneralMessages.RecordUpdated);
        }

        public async Task<Response<bool>> DeleteLesson(Guid lessonId, Guid userId)
        {
            // check if lesson exists
            var lesson = await _lessonRepository.GetLessonById(lessonId);
            if (lesson == null) {
                throw new KeyNotFoundException(GeneralMessages.InvalidLessonId);
            }

            // also remove all problems associated with that lesson
            if (lesson.Problems != null && lesson.Problems.Count() > 0) { 
                foreach (var problem in lesson.Problems){
                    problem.IsActive = false;
                    problem.UpdatedAt = DateTime.UtcNow;
                    problem.DeletedAt = DateTime.UtcNow;
                    problem.DeletedBy = userId;

                    // also remove choices?
                }
            }

            lesson.IsActive = false;
            lesson.UpdatedAt = DateTime.UtcNow;
            lesson.DeletedAt = DateTime.UtcNow;
            lesson.DeletedBy = userId;

            await _lessonRepository.SaveChanges();
            return new Response<bool>(true, true, GeneralMessages.RecordDeleted);
        }
    }
}

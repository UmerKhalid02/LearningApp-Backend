using LearningApp.Application.DataTransferObjects.LessonDTO;
using LearningApp.Application.Wrappers;

namespace LearningApp.Web.Modules.Lessons
{
    public interface ILessonService
    {
        public Task<Response<List<LessonResponseDTO>>> GetAllLessons();
        public Task<Response<List<LessonResponseDTO>>> GetAllLessonsByTopicId(Guid topicId);
        public Task<Response<LessonResponseDTO>> GetLessonById(Guid id);
        public Task<Response<LessonResponseDTO>> CreateLesson(LessonRequestDTO request);
        public Task<Response<LessonResponseDTO>> UpdateLesson(Guid lessonId, LessonRequestDTO request);
        public Task<Response<bool>> DeleteLesson(Guid lessonId);
    }
}

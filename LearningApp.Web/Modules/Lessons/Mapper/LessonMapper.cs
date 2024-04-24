using AutoMapper;
using LearningApp.Application.DataTransferObjects.LessonDTO;
using LearningApp.Data.Entities.ProblemEntity;

namespace LearningApp.Web.Modules.Lessons.Mapper
{
    public class LessonMapper : Profile
    {
        public LessonMapper()
        {
            LessonDetails();
            AddLesson();
        }

        void LessonDetails()
        {
            CreateMap<LessonProblemsDTO, Problem>().ReverseMap();
            CreateMap<LessonTopicDTO, Topic>().ReverseMap();
            CreateMap<LessonResponseDTO, Lesson>().ReverseMap();
        }

        void AddLesson()
        {
            CreateMap<LessonRequestDTO, Lesson>().ReverseMap();
        }
    }
}

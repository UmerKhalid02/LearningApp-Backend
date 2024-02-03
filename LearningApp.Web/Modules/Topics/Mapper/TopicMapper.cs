using AutoMapper;
using LearningApp.Application.DataTransferObjects.TopicDTO;
using LearningApp.Data.Entities.ProblemEntity;

namespace LearningApp.Web.Modules.Topics.Mapper
{
    public class TopicMapper : Profile
    {
        public TopicMapper()
        {
            TopicDetails();
        }

        public void TopicDetails()
        {
            CreateMap<LessonDTO, Lesson>().ReverseMap();
            CreateMap<Topic, TopicResponseDTO>().ReverseMap();
        }

    }
}

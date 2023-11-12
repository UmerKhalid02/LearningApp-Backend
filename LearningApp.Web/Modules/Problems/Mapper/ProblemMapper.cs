using AutoMapper;
using LearningApp.Application.DataTransferObjects.ProblemDTO;
using LearningApp.Data.Entities.ProblemEntity;

namespace LearningApp.Web.Modules.Problems.Mapper
{
    public class ProblemMapper : Profile
    {
        public ProblemMapper()
        {
            ProblemDetailsMapper();
            AddProblemMapper();
        }

        void ProblemDetailsMapper()
        {
            CreateMap<TopicDTO, Topic>().ReverseMap();
            CreateMap<ChoiceDTO, Choice>().ReverseMap();

            CreateMap<Problem, ProblemResponseDTO>()
                .ForMember(dest => dest.Topic, opt => opt.MapFrom(src => src.Topic))
                .ForMember(dest => dest.Choices, opt => opt.MapFrom(src => src.Choices))
                .ReverseMap();
        }

        void AddProblemMapper() 
        {
            CreateMap<Choice, ChoiceRequestDTO>().ReverseMap();

            CreateMap<AddProblemRequestDTO, Problem>()
                .ForPath(dest => dest.Choices, opt => opt.MapFrom(src => src.Choices))
                .ReverseMap();
        }

    }
}

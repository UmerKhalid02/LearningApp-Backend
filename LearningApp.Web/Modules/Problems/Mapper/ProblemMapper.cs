﻿using AutoMapper;
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
            UpdateProblemMApper();
        }

        void ProblemDetailsMapper()
        {
            CreateMap<LessonDTO, Lesson>().ReverseMap();
            CreateMap<ChoiceDTO, Choice>().ReverseMap();
            CreateMap<SolutionDTO, Solution>().ReverseMap();

            CreateMap<Problem, ProblemResponseDTO>()
                .ForMember(dest => dest.Lesson, opt => opt.MapFrom(src => src.Lesson))
                .ForMember(dest => dest.Choices, opt => opt.MapFrom(src => src.Choices))
                .ReverseMap();
        }

        void AddProblemMapper() 
        {
            CreateMap<Choice, ChoiceRequestDTO>().ReverseMap();
            CreateMap<Solution, SolutionRequestDTO>().ReverseMap();

            CreateMap<AddProblemRequestDTO, Problem>()
                .ForMember(dest => dest.Choices, opt => opt.MapFrom(src => src.Choices))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToUpper()))
                .ReverseMap();
        }

        void UpdateProblemMApper()
        {
            CreateMap<Choice, UpdateChoiceRequestDTO>().ReverseMap();

            CreateMap<UpdateProblemRequestDTO, Problem>()
                .ForMember(dest => dest.Choices, opt => opt.MapFrom(src => src.Choices))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToUpper()))
                .ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember, destMember) => srcMember != null));
        }

    }
}

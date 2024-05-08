using AutoMapper;
using LearningApp.Application.DataTransferObjects.ClassroomDTO;
using LearningApp.Data.Entities.ClassroomEntity;
using LearningApp.Data.Entities.UserEntity;

namespace LearningApp.Web.Modules.Classrooms.Mapper
{
    public class ClassroomMapper : Profile
    {
        public ClassroomMapper()
        {
            AddClassroomMapper();
            ClassroomDetailsMapper();
        }

        void AddClassroomMapper()
        {
            CreateMap<AddClassroomRequestDTO, Classroom>().ReverseMap();
        }

        void ClassroomDetailsMapper()
        {
            CreateMap<Student, User>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.StudentName))
                .ReverseMap();

            CreateMap<Classroom, ClassroomResponseDTO>()
                .ForMember(dest => dest.TotalStudents, opt => opt.MapFrom(src => src.UserClassrooms.Count))
                .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.UserClassrooms.Select(u => u.User)))
                .ReverseMap();
        }

    }
}

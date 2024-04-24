using AutoMapper;
using LearningApp.Application.DataTransferObjects.AuthenticationDTO;
using LearningApp.Data.Entities.UserEntity;

namespace LearningApp.Web.Modules.Authentication.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            AddUserMapper();
        }

        void AddUserMapper()
        { 
            CreateMap<User, RegisterRequestDTO>().ReverseMap();
        }
        

    }
}

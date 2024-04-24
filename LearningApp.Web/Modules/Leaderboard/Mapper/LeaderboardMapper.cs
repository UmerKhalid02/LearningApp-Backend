using AutoMapper;
using LearningApp.Application.DataTransferObjects.LeaderboardDTO;
using LearningApp.Data.Entities.UserEntity;

namespace LearningApp.Web.Modules.Leaderboard.Mapper
{
    public class LeaderboardMapper : Profile
    {
        public LeaderboardMapper() 
        {
            LeaderboardDetails();
        }

        void LeaderboardDetails()
        { 
            CreateMap<User, LeaderboardResponseDTO>().ReverseMap();
        }
    }
}

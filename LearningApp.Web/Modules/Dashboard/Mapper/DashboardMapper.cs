using AutoMapper;
using LearningApp.Application.DataTransferObjects.DashboardDTO;
using LearningApp.Data.Entities.UserEntity;

namespace LearningApp.Web.Modules.Dashboard.Mapper
{
    public class DashboardMapper : Profile
    {
        public DashboardMapper()
        {
            DashboardDetailsMapper();
        }

        void DashboardDetailsMapper()
        { 
            CreateMap<DashboardResponseDTO, User>().ReverseMap();
        }

    }
}

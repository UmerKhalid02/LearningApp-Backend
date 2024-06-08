using AutoMapper;
using LearningApp.Application.DataTransferObjects.DashboardDTO;
using LearningApp.Application.Enums;
using LearningApp.Application.Wrappers;
using LearningApp.Data.Entities;
using LearningApp.Data.Entities.UserEntity;
using LearningApp.Data.IRepositories.IDashboardRepository;
using LearningApp.Data.IRepositories.IRecentUserLessonsRepository;

namespace LearningApp.Web.Modules.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;
        private readonly IRecentUserLessonsRepository _recentUserLessonsRepository;
        private readonly IMapper _mapper;
        public DashboardService(IDashboardRepository dashboardRepository, IRecentUserLessonsRepository recentUserLessonsRepository, IMapper mapper)
        {
            _dashboardRepository = dashboardRepository;
            _recentUserLessonsRepository = recentUserLessonsRepository;
            _mapper = mapper;
        }

        private async Task UserMultiplierHandler(User user, UserLoginTime loginTime)
        {
            TimeSpan timeSpan =  DateTime.UtcNow - (DateTime)loginTime.LoginAt;

            if (timeSpan.TotalHours > 20 && timeSpan.TotalHours <= 28) {
                user.Multiplier += 0.5;
                loginTime.LoginAt = DateTime.UtcNow;
                await _dashboardRepository.SaveChangesAsync();
            }
            else if (timeSpan.TotalHours > 24) {
                if (user.Multiplier != 1) { 
                    user.Multiplier = 1;
                    loginTime.LoginAt = DateTime.UtcNow;
                    await _dashboardRepository.SaveChangesAsync();
                }
            }
        }

        public async Task<Response<DashboardResponseDTO>> GetDashboard(Guid userId, string role)
        {
            var user = await _dashboardRepository.GetUserDetails(userId);
            if (user == null) {
                throw new UnauthorizedAccessException(GeneralMessages.UnauthorizedAccess);
            }

            var userLoginTime = await _dashboardRepository.GetUserLoginTime(userId);

            if (userLoginTime == null) { 
                throw new UnauthorizedAccessException(GeneralMessages.UnauthorizedAccess);
            }

            // multplier handler
            if ((role == RolesKey.ST || role == RolesKey.TR) && userLoginTime.LoginAt != null)
            {
                await UserMultiplierHandler(userLoginTime.User, userLoginTime);
            }

            // retreive recent lessons
            var recentUserLessons = await _recentUserLessonsRepository.GetAllRecentUserLessons(userId);
            var recentUserLessonsResponse = _mapper.Map<List<RecentLessonsDTO>>(recentUserLessons.Select(x => x.Lesson));

            DashboardResponseDTO responseDTO = _mapper.Map<DashboardResponseDTO>(user);
            responseDTO.Role = role;
            responseDTO.recentLessons = recentUserLessonsResponse;
            
            return new Response<DashboardResponseDTO>(true, responseDTO, "Dashboard Response");
        }
    }
}

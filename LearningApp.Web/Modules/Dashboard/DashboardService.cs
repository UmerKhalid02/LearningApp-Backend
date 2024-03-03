using LearningApp.Application.DataTransferObjects.DashboardDTO;
using LearningApp.Application.Enums;
using LearningApp.Application.Wrappers;
using LearningApp.Data.Entities;
using LearningApp.Data.Entities.UserEntity;
using LearningApp.Data.IRepositories.IDashboardRepository;

namespace LearningApp.Web.Modules.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;
        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        private async Task UserMultiplierHandler(User user, UserLoginTime loginTime)
        {
            TimeSpan timeSpan =  DateTime.UtcNow - (DateTime)loginTime.LoginAt;

            if (timeSpan.TotalHours > 18 && timeSpan.TotalHours <= 24) {
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
            var userLoginTime = await _dashboardRepository.GetUserLoginTime(userId);

            if (userLoginTime == null) { 
                throw new UnauthorizedAccessException(GeneralMessages.UnauthorizedAccess);
            }

            // multplier handler
            if (role == RolesKey.ST && userLoginTime.LoginAt != null)
            {
                await UserMultiplierHandler(userLoginTime.User, userLoginTime);
            }

            DashboardResponseDTO responseDTO = new()
            {
                Multiplier = userLoginTime.User.Multiplier
            };

            return new Response<DashboardResponseDTO>(true, responseDTO, "Dashboard Response");
        }
    }
}

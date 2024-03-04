using LearningApp.Application.DataTransferObjects.DashboardDTO;
using LearningApp.Application.Wrappers;

namespace LearningApp.Web.Modules.Dashboard
{
    public interface IDashboardService
    {
        public Task<Response<DashboardResponseDTO>> GetDashboard(Guid userId, string role);
    }
}

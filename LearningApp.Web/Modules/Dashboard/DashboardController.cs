using LearningApp.Web.Modules.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningApp.Web.Modules.Dashboard
{
    [Route("api/v1/dashboard")]
    public class DashboardController : BaseController
    {
        private readonly IDashboardService _dashboardService;
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [Authorize(Roles = "AD, ST, TR")]
        [HttpGet]
        public async Task<IActionResult> GetDashboard()
        {
            var userId = this.GetUserId();
            var userRole = this.GetUserRole();

            var resposne = await _dashboardService.GetDashboard(userId, userRole);

            return Ok(resposne);
        }

    }
}

using LearningApp.Application.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LearningApp.Web.Modules.Common
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected Guid GetUserId()
        {
            try
            {
                Guid userId = Guid.Parse(User.Claims.First(i => i.Type == "UserId").Value);
                return userId;
            }
            catch
            {
                throw new UnauthorizedAccessException(GeneralMessages.InvalidToken);
            }
        }

        protected string GetUserRole()
        {
            try
            {
                string userRole = User.FindFirstValue(ClaimTypes.Role);
                return userRole;
            }
            catch
            {
                throw new UnauthorizedAccessException(GeneralMessages.InvalidToken);
            }
        }
    }
}

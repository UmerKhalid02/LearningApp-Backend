using LearningApp.Application.Enums;
using Microsoft.AspNetCore.Mvc;

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
            catch (Exception)
            {
                throw new Exception(GeneralMessages.InvalidToken);
            }
        }
    }
}

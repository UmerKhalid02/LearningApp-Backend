using LearningApp.Application.DataTransferObjects.AuthenticationDTO;

namespace LearningApp.Web.Modules.Authentication
{
    public interface IAuthenticationService
    {
        public Task Authenticate(LoginRequestDTO request);
    }
}

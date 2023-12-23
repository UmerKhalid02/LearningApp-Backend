using LearningApp.Application.DataTransferObjects.AuthenticationDTO;
using LearningApp.Application.Wrappers;

namespace LearningApp.Web.Modules.Authentication
{
    public interface IAuthenticationService
    {
        public Task Authenticate(LoginRequestDTO request);
        public Task<Response<bool>> Register(RegisterRequestDTO request);
    }
}

using LearningApp.Application.DataTransferObjects.AuthenticationDTO;
using LearningApp.Application.Wrappers;

namespace LearningApp.Web.Modules.Authentication
{
    public interface IAuthenticationService
    {
        public Task<Response<LoginResponseDTO>> Authenticate(LoginRequestDTO request);
        Task<Response<bool>> LogoutService(LogoutRequestModel model);
        public Task<Response<bool>> Register(RegisterRequestDTO request);
    }
}

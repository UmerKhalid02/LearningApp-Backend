using LearningApp.Application.DataTransferObjects.AuthenticationDTO;
using LearningApp.Data.IRepositories.IAuthenticationRepository;

namespace LearningApp.Web.Modules.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;


        public AuthenticationService(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }


        public Task Authenticate(LoginRequestDTO request)
        {
            throw new NotImplementedException();
        }
    }
}

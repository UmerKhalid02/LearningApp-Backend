
using LearningApp.Application.DataTransferObjects.AuthenticationDTO;
using LearningApp.Data.Entities.UserEntity;

namespace LearningApp.Data.IRepositories.IAuthenticationRepository
{
    public interface IAuthenticationRepository
    {
        public Task<LoginResponseDTO> Authenticate(LoginRequestDTO request);
        Task<bool> Logout(LogoutRequestModel model);
        public Task<User?> GetUserByUserName(string username);
        public Task<User?> GetUserByEmail(string email);
        public Task<User> AddUser(User user);
        public Task<UserRole> AddUserRole(UserRole userRole);
        public Task SaveChanges();
    }
}

using LearningApp.Data.Entities.UserEntity;

namespace LearningApp.Data.IRepositories.IUserRepository
{
    public interface IUserRepository
    {
        Task<User> GetUserById(Guid userId);
    }
}

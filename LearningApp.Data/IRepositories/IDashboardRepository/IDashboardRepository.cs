using LearningApp.Data.Entities;
using LearningApp.Data.Entities.UserEntity;

namespace LearningApp.Data.IRepositories.IDashboardRepository
{
    public interface IDashboardRepository
    {
        public Task<UserLoginTime?> GetUserLoginTime(Guid userId);
        public Task<User> GetUserDetails(Guid userId);
        public Task SaveChangesAsync();
    }
}

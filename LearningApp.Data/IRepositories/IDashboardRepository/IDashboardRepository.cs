using LearningApp.Data.Entities;

namespace LearningApp.Data.IRepositories.IDashboardRepository
{
    public interface IDashboardRepository
    {
        public Task<UserLoginTime?> GetUserLoginTime(Guid userId);
        public Task SaveChangesAsync();
    }
}

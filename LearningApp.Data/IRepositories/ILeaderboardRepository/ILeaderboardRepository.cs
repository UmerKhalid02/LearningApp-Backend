using LearningApp.Data.Entities.UserEntity;

namespace LearningApp.Data.IRepositories.ILeaderboardRepository
{
    public interface ILeaderboardRepository
    {
        public Task<List<User>> GetLeaderboardUsersTop100();
    }
}

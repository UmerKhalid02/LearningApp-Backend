using LearningApp.Data.Entities.UserEntity;
using LearningApp.Data.IRepositories.IUserRepository;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Data.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly EFDataContext _context;
        public UserRepository(EFDataContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserById(Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId && x.IsActive);
            return user;
        }
    }
}

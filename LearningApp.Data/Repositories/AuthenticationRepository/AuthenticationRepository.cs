using LearningApp.Data.Entities.UserEntity;
using LearningApp.Data.IRepositories.IAuthenticationRepository;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Data.Repositories.AuthenticationRepository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly EFDataContext _context;

        public AuthenticationRepository(EFDataContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _context.Users.Where(x => x.Email == email && x.IsActive).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User?> GetUserByUserName(string username)
        {
            var user = await _context.Users.Where(x => x.UserName == username && x.IsActive).FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            return user;
        }

        public async Task<UserRole> AddUserRole(UserRole userRole)
        {
            await _context.UserRoles.AddAsync(userRole);
            return userRole;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        
    }
}

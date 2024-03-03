﻿using LearningApp.Data.Entities;
using LearningApp.Data.Entities.UserEntity;
using LearningApp.Data.IRepositories.IDashboardRepository;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Data.Repositories.DashboardRepository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly EFDataContext _context;
        public DashboardRepository(EFDataContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserDetails(Guid userId) => 
            await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId && u.IsActive);

        public async Task<UserLoginTime?> GetUserLoginTime(Guid userId) =>
            await _context.UserLoginTime.Include(x => x.User).Where(x => x.UserId == userId).FirstOrDefaultAsync();

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
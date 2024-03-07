﻿using LearningApp.Data.Entities.UserEntity;
using LearningApp.Data.IRepositories.ILeaderboardRepository;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Data.Repositories.LeaderboardRepository
{
    public class LeaderboardRepository : ILeaderboardRepository
    {
        private readonly EFDataContext _context;
        public LeaderboardRepository(EFDataContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetLeaderboardStudentsTop100()
        {
            var users = await _context.Users.Include(x => x.UserRole).ThenInclude(x => x.Role).Where(x => x.IsActive && x.UserRole.Role.RoleName == "ST").OrderByDescending(x => x.XP).Take(100).ToListAsync();
            return users;
        }
    }
}

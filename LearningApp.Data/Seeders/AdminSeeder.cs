using LearningApp.Application.Enums;
using LearningApp.Data.Entities.UserEntity;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Data.Seeders
{
    public static class AdminSeeder
    {
        public static void SeedAdmin(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasData(
                new User
                {
                    UserId = Guid.Parse("B29A769C-2F0C-4A2B-A72D-71CDD4C98502"),
                    FullName = "admin",
                    UserName = "admin",
                    Password = "admin123",
                    Email = "admin@admin.com",
                    IsActive = true,
                });

            modelBuilder.Entity<UserRole>()
                    .HasData(
                    new UserRole
                    {
                        UserRoleId = Guid.Parse("65AE02D5-E00F-433A-8D75-71C20B883C5F"),
                        UserId = Guid.Parse("B29A769C-2F0C-4A2B-A72D-71CDD4C98502"),
                        RoleId = RolesKey.AdminRoleId,
                        IsActive = true
                    });
        }
    }
}

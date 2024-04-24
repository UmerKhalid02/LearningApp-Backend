using LearningApp.Application.Enums;
using LearningApp.Data.Entities.AuthenticationEntity;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Data.Seeders
{
    public static class RoleSeeder
    {
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
               .HasData(
                new Role
                {
                    RoleId = RolesKey.AdminRoleId,
                    RoleName = RolesKey.AD,
                    Description = "Admin",
                    IsActive = true,
                    CreatedAt = DateTime.Parse("2024-01-01")
                },
               new Role
               {
                   RoleId = RolesKey.StudentRoleId,
                   RoleName = RolesKey.ST,
                   Description = "Student",
                   IsActive = true,
                   CreatedAt = DateTime.Parse("2024-01-01")
               },
               new Role
               {
                   RoleId = RolesKey.TeacherRoleId,
                   RoleName = RolesKey.TR,
                   Description = "Teacher",
                   IsActive = true,
                   CreatedAt = DateTime.Parse("2024-01-01")
               });
        }
    }
}

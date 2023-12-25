using LearningApp.Data.Entities;
using LearningApp.Data.Entities.AuthenticationEntity;
using LearningApp.Data.Entities.ProblemEntity;
using LearningApp.Data.Entities.UserEntity;
using LearningApp.Data.Seeders;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Data
{
    public class EFDataContext : DbContext
    {
        public EFDataContext(DbContextOptions<EFDataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<UserLogin> UserLogin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("edu");
            modelBuilder.SeedRoles();
        }
    }
}

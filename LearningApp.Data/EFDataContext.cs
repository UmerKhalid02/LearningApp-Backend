using LearningApp.Data.Entities.AuthenticationEntity;
using LearningApp.Data.Entities.UserEntity;
using Microsoft.EntityFrameworkCore;

namespace LearningApp.Data
{
    public class EFDataContext : DbContext
    {
        public EFDataContext(DbContextOptions<EFDataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("edu");
        }
    }
}

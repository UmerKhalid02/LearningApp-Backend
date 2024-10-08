﻿using LearningApp.Data.Entities;
using LearningApp.Data.Entities.AuthenticationEntity;
using LearningApp.Data.Entities.ClassroomEntity;
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
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<UserLogin> UserLogin { get; set; }
        public DbSet<UserLoginTime> UserLoginTime { get; set; }
        public DbSet<UserProgress> UserProgress { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<UserClassroom> UserClassrooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("edu");
            modelBuilder.SeedRoles();
            modelBuilder.SeedAdmin();
        }
    }
}

﻿// <auto-generated />
using System;
using LearningApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LearningApp.Data.Migrations
{
    [DbContext(typeof(EFDataContext))]
    partial class EFDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("edu")
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LearningApp.Data.Entities.AuthenticationEntity.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RoleID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId");

                    b.ToTable("Roles", "edu");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("35dc76b5-8de7-4eb3-a29c-9a05686a6f89"),
                            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Admin",
                            IsActive = true,
                            RoleName = "AD"
                        },
                        new
                        {
                            RoleId = new Guid("2bd8f739-13c4-46e2-b0cc-5888851f373a"),
                            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Student",
                            IsActive = true,
                            RoleName = "ST"
                        },
                        new
                        {
                            RoleId = new Guid("bf7669ac-c46a-4dea-bfa0-8d8aef1d9347"),
                            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Teacher",
                            IsActive = true,
                            RoleName = "TR"
                        });
                });

            modelBuilder.Entity("LearningApp.Data.Entities.ClassroomEntity.Classroom", b =>
                {
                    b.Property<Guid>("ClassroomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ClassroomID");

                    b.Property<string>("ClassroomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ClassroomId");

                    b.ToTable("Classroom", "edu");
                });

            modelBuilder.Entity("LearningApp.Data.Entities.ClassroomEntity.UserClassroom", b =>
                {
                    b.Property<Guid>("UserClassroomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserClassroomID");

                    b.Property<Guid>("ClassroomId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ClassroomID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserID");

                    b.HasKey("UserClassroomId");

                    b.HasIndex("ClassroomId");

                    b.HasIndex("UserId");

                    b.ToTable("UserClassroom", "edu");
                });

            modelBuilder.Entity("LearningApp.Data.Entities.ProblemEntity.Choice", b =>
                {
                    b.Property<Guid>("ChoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ChoiceID");

                    b.Property<string>("ChoiceText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProblemId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProblemID");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ChoiceId");

                    b.HasIndex("ProblemId");

                    b.ToTable("Choice", "edu");
                });

            modelBuilder.Entity("LearningApp.Data.Entities.ProblemEntity.Lesson", b =>
                {
                    b.Property<Guid>("LessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("LessonID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LessonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LessonNumber")
                        .HasColumnType("int");

                    b.Property<Guid>("TopicId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TopicID");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LessonId");

                    b.HasIndex("TopicId");

                    b.ToTable("Lesson", "edu");
                });

            modelBuilder.Entity("LearningApp.Data.Entities.ProblemEntity.Problem", b =>
                {
                    b.Property<Guid>("ProblemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProblemID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("LessonId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("LessonID");

                    b.Property<string>("SampleCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProblemId");

                    b.HasIndex("LessonId");

                    b.ToTable("Problem", "edu");
                });

            modelBuilder.Entity("LearningApp.Data.Entities.ProblemEntity.Solution", b =>
                {
                    b.Property<Guid>("SolutionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("ProblemId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProblemID");

                    b.Property<string>("SolutionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SolutionId");

                    b.HasIndex("ProblemId");

                    b.ToTable("Solution", "edu");
                });

            modelBuilder.Entity("LearningApp.Data.Entities.ProblemEntity.Topic", b =>
                {
                    b.Property<Guid>("TopicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TopicID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("TopicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("TopicId");

                    b.ToTable("Topic", "edu");
                });

            modelBuilder.Entity("LearningApp.Data.Entities.UserEntity.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<double>("Multiplier")
                        .HasColumnType("float");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalXP")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("XP")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("User", "edu");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("b29a769c-2f0c-4a2b-a72d-71cdd4c98502"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@admin.com",
                            FullName = "admin",
                            IsActive = true,
                            Level = 1,
                            Multiplier = 1.0,
                            Password = "admin123",
                            TotalXP = 0,
                            UserName = "admin",
                            XP = 0
                        });
                });

            modelBuilder.Entity("LearningApp.Data.Entities.UserEntity.UserProgress", b =>
                {
                    b.Property<Guid>("UserProgressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("LessonId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("LessonID");

                    b.Property<bool>("TopicCompleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("TopicId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TopicID");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserID");

                    b.HasKey("UserProgressId");

                    b.HasIndex("LessonId");

                    b.ToTable("UserProgress", "edu");
                });

            modelBuilder.Entity("LearningApp.Data.Entities.UserEntity.UserRole", b =>
                {
                    b.Property<Guid>("UserRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserRoleID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RoleID");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserID");

                    b.HasKey("UserRoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserRole", "edu");

                    b.HasData(
                        new
                        {
                            UserRoleId = new Guid("65ae02d5-e00f-433a-8d75-71c20b883c5f"),
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            RoleId = new Guid("35dc76b5-8de7-4eb3-a29c-9a05686a6f89"),
                            UserId = new Guid("b29a769c-2f0c-4a2b-a72d-71cdd4c98502")
                        });
                });

            modelBuilder.Entity("LearningApp.Data.Entities.UserLogin", b =>
                {
                    b.Property<Guid>("UserLoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserLoginID");

                    b.Property<DateTime?>("LogOutAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenCreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RefreshTokenUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserLoginId");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin", "edu");
                });

            modelBuilder.Entity("LearningApp.Data.Entities.UserLoginTime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<DateTime?>("LoginAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserLoginTime", "edu");
                });

            modelBuilder.Entity("LearningApp.Data.Entities.ClassroomEntity.UserClassroom", b =>
                {
                    b.HasOne("LearningApp.Data.Entities.ClassroomEntity.Classroom", "Classroom")
                        .WithMany("UserClassrooms")
                        .HasForeignKey("ClassroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearningApp.Data.Entities.UserEntity.User", "User")
                        .WithMany("UserClassroom")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LearningApp.Data.Entities.ProblemEntity.Choice", b =>
                {
                    b.HasOne("LearningApp.Data.Entities.ProblemEntity.Problem", null)
                        .WithMany("Choices")
                        .HasForeignKey("ProblemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LearningApp.Data.Entities.ProblemEntity.Lesson", b =>
                {
                    b.HasOne("LearningApp.Data.Entities.ProblemEntity.Topic", "Topic")
                        .WithMany("Lessons")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("LearningApp.Data.Entities.ProblemEntity.Problem", b =>
                {
                    b.HasOne("LearningApp.Data.Entities.ProblemEntity.Lesson", "Lesson")
                        .WithMany("Problems")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("LearningApp.Data.Entities.ProblemEntity.Solution", b =>
                {
                    b.HasOne("LearningApp.Data.Entities.ProblemEntity.Problem", null)
                        .WithMany("Solution")
                        .HasForeignKey("ProblemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LearningApp.Data.Entities.UserEntity.UserProgress", b =>
                {
                    b.HasOne("LearningApp.Data.Entities.ProblemEntity.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId");

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("LearningApp.Data.Entities.UserEntity.UserRole", b =>
                {
                    b.HasOne("LearningApp.Data.Entities.AuthenticationEntity.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearningApp.Data.Entities.UserEntity.User", "User")
                        .WithOne("UserRole")
                        .HasForeignKey("LearningApp.Data.Entities.UserEntity.UserRole", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LearningApp.Data.Entities.UserLogin", b =>
                {
                    b.HasOne("LearningApp.Data.Entities.UserEntity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LearningApp.Data.Entities.UserLoginTime", b =>
                {
                    b.HasOne("LearningApp.Data.Entities.UserEntity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LearningApp.Data.Entities.ClassroomEntity.Classroom", b =>
                {
                    b.Navigation("UserClassrooms");
                });

            modelBuilder.Entity("LearningApp.Data.Entities.ProblemEntity.Lesson", b =>
                {
                    b.Navigation("Problems");
                });

            modelBuilder.Entity("LearningApp.Data.Entities.ProblemEntity.Problem", b =>
                {
                    b.Navigation("Choices");

                    b.Navigation("Solution");
                });

            modelBuilder.Entity("LearningApp.Data.Entities.ProblemEntity.Topic", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("LearningApp.Data.Entities.UserEntity.User", b =>
                {
                    b.Navigation("UserClassroom");

                    b.Navigation("UserRole")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

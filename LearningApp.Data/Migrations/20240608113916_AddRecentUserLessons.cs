using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningApp.Data.Migrations
{
    public partial class AddRecentUserLessons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecentUserLessons",
                schema: "edu",
                columns: table => new
                {
                    RecentUserLessonsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecentUserLessons", x => x.RecentUserLessonsId);
                    table.ForeignKey(
                        name: "FK_RecentUserLessons_Lesson_LessonID",
                        column: x => x.LessonID,
                        principalSchema: "edu",
                        principalTable: "Lesson",
                        principalColumn: "LessonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecentUserLessons_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "edu",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecentUserLessons_LessonID",
                schema: "edu",
                table: "RecentUserLessons",
                column: "LessonID");

            migrationBuilder.CreateIndex(
                name: "IX_RecentUserLessons_UserID",
                schema: "edu",
                table: "RecentUserLessons",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecentUserLessons",
                schema: "edu");
        }
    }
}

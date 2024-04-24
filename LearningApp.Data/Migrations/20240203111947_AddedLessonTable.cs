using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningApp.Data.Migrations
{
    public partial class AddedLessonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problem_Topic_TopicID",
                schema: "edu",
                table: "Problem");

            migrationBuilder.DropColumn(
                name: "TotalLessons",
                schema: "edu",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "LessonNumber",
                schema: "edu",
                table: "Problem");

            migrationBuilder.RenameColumn(
                name: "TopicID",
                schema: "edu",
                table: "Problem",
                newName: "LessonID");

            migrationBuilder.RenameIndex(
                name: "IX_Problem_TopicID",
                schema: "edu",
                table: "Problem",
                newName: "IX_Problem_LessonID");

            migrationBuilder.CreateTable(
                name: "Lesson",
                schema: "edu",
                columns: table => new
                {
                    LessonID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LessonNumber = table.Column<int>(type: "int", nullable: false),
                    LessonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopicID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesson", x => x.LessonID);
                    table.ForeignKey(
                        name: "FK_Lesson_Topic_TopicID",
                        column: x => x.TopicID,
                        principalSchema: "edu",
                        principalTable: "Topic",
                        principalColumn: "TopicID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lesson_TopicID",
                schema: "edu",
                table: "Lesson",
                column: "TopicID");

            migrationBuilder.AddForeignKey(
                name: "FK_Problem_Lesson_LessonID",
                schema: "edu",
                table: "Problem",
                column: "LessonID",
                principalSchema: "edu",
                principalTable: "Lesson",
                principalColumn: "LessonID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problem_Lesson_LessonID",
                schema: "edu",
                table: "Problem");

            migrationBuilder.DropTable(
                name: "Lesson",
                schema: "edu");

            migrationBuilder.RenameColumn(
                name: "LessonID",
                schema: "edu",
                table: "Problem",
                newName: "TopicID");

            migrationBuilder.RenameIndex(
                name: "IX_Problem_LessonID",
                schema: "edu",
                table: "Problem",
                newName: "IX_Problem_TopicID");

            migrationBuilder.AddColumn<int>(
                name: "TotalLessons",
                schema: "edu",
                table: "Topic",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LessonNumber",
                schema: "edu",
                table: "Problem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Problem_Topic_TopicID",
                schema: "edu",
                table: "Problem",
                column: "TopicID",
                principalSchema: "edu",
                principalTable: "Topic",
                principalColumn: "TopicID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

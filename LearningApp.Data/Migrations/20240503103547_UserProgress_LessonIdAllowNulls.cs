using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningApp.Data.Migrations
{
    public partial class UserProgress_LessonIdAllowNulls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProgress_Lesson_LessonID",
                schema: "edu",
                table: "UserProgress");

            migrationBuilder.AlterColumn<Guid>(
                name: "LessonID",
                schema: "edu",
                table: "UserProgress",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProgress_Lesson_LessonID",
                schema: "edu",
                table: "UserProgress",
                column: "LessonID",
                principalSchema: "edu",
                principalTable: "Lesson",
                principalColumn: "LessonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProgress_Lesson_LessonID",
                schema: "edu",
                table: "UserProgress");

            migrationBuilder.AlterColumn<Guid>(
                name: "LessonID",
                schema: "edu",
                table: "UserProgress",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProgress_Lesson_LessonID",
                schema: "edu",
                table: "UserProgress",
                column: "LessonID",
                principalSchema: "edu",
                principalTable: "Lesson",
                principalColumn: "LessonID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

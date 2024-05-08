using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningApp.Data.Migrations
{
    public partial class UpdatedClassroomTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ClassroomID",
                schema: "edu",
                table: "Topic",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClassroomCode",
                schema: "edu",
                table: "Classroom",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClassroomDescription",
                schema: "edu",
                table: "Classroom",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topic_ClassroomID",
                schema: "edu",
                table: "Topic",
                column: "ClassroomID");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Classroom_ClassroomID",
                schema: "edu",
                table: "Topic",
                column: "ClassroomID",
                principalSchema: "edu",
                principalTable: "Classroom",
                principalColumn: "ClassroomID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Classroom_ClassroomID",
                schema: "edu",
                table: "Topic");

            migrationBuilder.DropIndex(
                name: "IX_Topic_ClassroomID",
                schema: "edu",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "ClassroomID",
                schema: "edu",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "ClassroomCode",
                schema: "edu",
                table: "Classroom");

            migrationBuilder.DropColumn(
                name: "ClassroomDescription",
                schema: "edu",
                table: "Classroom");
        }
    }
}

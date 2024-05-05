using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningApp.Data.Migrations
{
    public partial class UserClassroomFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserClassroom_UserID",
                schema: "edu",
                table: "UserClassroom");

            migrationBuilder.CreateIndex(
                name: "IX_UserClassroom_UserID",
                schema: "edu",
                table: "UserClassroom",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserClassroom_UserID",
                schema: "edu",
                table: "UserClassroom");

            migrationBuilder.CreateIndex(
                name: "IX_UserClassroom_UserID",
                schema: "edu",
                table: "UserClassroom",
                column: "UserID",
                unique: true);
        }
    }
}

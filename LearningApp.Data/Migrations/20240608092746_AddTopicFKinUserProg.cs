using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningApp.Data.Migrations
{
    public partial class AddTopicFKinUserProg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserProgress_TopicID",
                schema: "edu",
                table: "UserProgress",
                column: "TopicID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProgress_Topic_TopicID",
                schema: "edu",
                table: "UserProgress",
                column: "TopicID",
                principalSchema: "edu",
                principalTable: "Topic",
                principalColumn: "TopicID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProgress_Topic_TopicID",
                schema: "edu",
                table: "UserProgress");

            migrationBuilder.DropIndex(
                name: "IX_UserProgress_TopicID",
                schema: "edu",
                table: "UserProgress");
        }
    }
}

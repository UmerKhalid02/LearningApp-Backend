using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningApp.Data.Migrations
{
    public partial class AddedUserClassroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classroom",
                schema: "edu",
                columns: table => new
                {
                    ClassroomID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassroomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Classroom", x => x.ClassroomID);
                });

            migrationBuilder.CreateTable(
                name: "UserClassroom",
                schema: "edu",
                columns: table => new
                {
                    UserClassroomID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassroomID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_UserClassroom", x => x.UserClassroomID);
                    table.ForeignKey(
                        name: "FK_UserClassroom_Classroom_ClassroomID",
                        column: x => x.ClassroomID,
                        principalSchema: "edu",
                        principalTable: "Classroom",
                        principalColumn: "ClassroomID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserClassroom_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "edu",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserClassroom_ClassroomID",
                schema: "edu",
                table: "UserClassroom",
                column: "ClassroomID");

            migrationBuilder.CreateIndex(
                name: "IX_UserClassroom_UserID",
                schema: "edu",
                table: "UserClassroom",
                column: "UserID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserClassroom",
                schema: "edu");

            migrationBuilder.DropTable(
                name: "Classroom",
                schema: "edu");
        }
    }
}

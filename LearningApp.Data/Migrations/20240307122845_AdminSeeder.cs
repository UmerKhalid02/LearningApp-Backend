using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningApp.Data.Migrations
{
    public partial class AdminSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "edu",
                table: "User",
                columns: new[] { "UserID", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Email", "FullName", "IsActive", "Level", "Multiplier", "Password", "TotalXP", "UpdatedAt", "UpdatedBy", "UserName", "XP" },
                values: new object[] { new Guid("b29a769c-2f0c-4a2b-a72d-71cdd4c98502"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "admin@admin.com", "admin", false, 1, 1.0, "admin123", 0, null, null, "admin", 0 });

            migrationBuilder.InsertData(
                schema: "edu",
                table: "UserRole",
                columns: new[] { "UserRoleID", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "IsActive", "RoleID", "UpdatedAt", "UpdatedBy", "UserID" },
                values: new object[] { new Guid("65ae02d5-e00f-433a-8d75-71c20b883c5f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, false, new Guid("35dc76b5-8de7-4eb3-a29c-9a05686a6f89"), null, null, new Guid("b29a769c-2f0c-4a2b-a72d-71cdd4c98502") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "edu",
                table: "UserRole",
                keyColumn: "UserRoleID",
                keyValue: new Guid("65ae02d5-e00f-433a-8d75-71c20b883c5f"));

            migrationBuilder.DeleteData(
                schema: "edu",
                table: "User",
                keyColumn: "UserID",
                keyValue: new Guid("b29a769c-2f0c-4a2b-a72d-71cdd4c98502"));
        }
    }
}

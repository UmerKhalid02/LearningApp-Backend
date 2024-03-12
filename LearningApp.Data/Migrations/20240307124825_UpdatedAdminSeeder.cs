using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningApp.Data.Migrations
{
    public partial class UpdatedAdminSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "edu",
                table: "User",
                keyColumn: "UserID",
                keyValue: new Guid("b29a769c-2f0c-4a2b-a72d-71cdd4c98502"),
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "edu",
                table: "UserRole",
                keyColumn: "UserRoleID",
                keyValue: new Guid("65ae02d5-e00f-433a-8d75-71c20b883c5f"),
                column: "IsActive",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "edu",
                table: "User",
                keyColumn: "UserID",
                keyValue: new Guid("b29a769c-2f0c-4a2b-a72d-71cdd4c98502"),
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                schema: "edu",
                table: "UserRole",
                keyColumn: "UserRoleID",
                keyValue: new Guid("65ae02d5-e00f-433a-8d75-71c20b883c5f"),
                column: "IsActive",
                value: false);
        }
    }
}

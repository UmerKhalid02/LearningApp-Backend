using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningApp.Data.Migrations
{
    public partial class SeededRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "edu",
                table: "Roles",
                columns: new[] { "RoleID", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "IsActive", "RoleName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("2bd8f739-13c4-46e2-b0cc-5888851f373a"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Student", true, "ST", null, null });

            migrationBuilder.InsertData(
                schema: "edu",
                table: "Roles",
                columns: new[] { "RoleID", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "IsActive", "RoleName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("35dc76b5-8de7-4eb3-a29c-9a05686a6f89"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Admin", true, "AD", null, null });

            migrationBuilder.InsertData(
                schema: "edu",
                table: "Roles",
                columns: new[] { "RoleID", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "IsActive", "RoleName", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("bf7669ac-c46a-4dea-bfa0-8d8aef1d9347"), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Teacher", true, "TR", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "edu",
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: new Guid("2bd8f739-13c4-46e2-b0cc-5888851f373a"));

            migrationBuilder.DeleteData(
                schema: "edu",
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: new Guid("35dc76b5-8de7-4eb3-a29c-9a05686a6f89"));

            migrationBuilder.DeleteData(
                schema: "edu",
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: new Guid("bf7669ac-c46a-4dea-bfa0-8d8aef1d9347"));
        }
    }
}

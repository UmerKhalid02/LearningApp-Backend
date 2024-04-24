using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningApp.Data.Migrations
{
    public partial class RemovedBEFromSol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "edu",
                table: "Solution");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "edu",
                table: "Solution");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "edu",
                table: "Solution");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "edu",
                table: "Solution");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "edu",
                table: "Solution");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "edu",
                table: "Solution");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "edu",
                table: "Solution",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                schema: "edu",
                table: "Solution",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "edu",
                table: "Solution",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeletedBy",
                schema: "edu",
                table: "Solution",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "edu",
                table: "Solution",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UpdatedBy",
                schema: "edu",
                table: "Solution",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}

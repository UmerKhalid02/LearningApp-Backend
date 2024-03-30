using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningApp.Data.Migrations
{
    public partial class AddedSolutionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Solution",
                schema: "edu",
                table: "Problem");

            migrationBuilder.CreateTable(
                name: "Solution",
                schema: "edu",
                columns: table => new
                {
                    SolutionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProblemID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SolutionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Solution", x => x.SolutionId);
                    table.ForeignKey(
                        name: "FK_Solution_Problem_ProblemID",
                        column: x => x.ProblemID,
                        principalSchema: "edu",
                        principalTable: "Problem",
                        principalColumn: "ProblemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solution_ProblemID",
                schema: "edu",
                table: "Solution",
                column: "ProblemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solution",
                schema: "edu");

            migrationBuilder.AddColumn<string>(
                name: "Solution",
                schema: "edu",
                table: "Problem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

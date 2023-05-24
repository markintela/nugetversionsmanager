using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EpicFeature",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpicFeature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solution",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    SubModule = table.Column<string>(type: "TEXT", nullable: true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sprint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprint", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardJira",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    SprintId = table.Column<Guid>(type: "TEXT", nullable: true),
                    EpicId = table.Column<Guid>(type: "TEXT", nullable: true),
                    EpicStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    GitBranch = table.Column<string>(type: "TEXT", nullable: true),
                    HasDataContractChanges = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeveloperId = table.Column<Guid>(type: "TEXT", nullable: true),
                    JiraNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardJira", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardJira_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CardJira_EpicFeature_EpicId",
                        column: x => x.EpicId,
                        principalTable: "EpicFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CardJira_Sprint_SprintId",
                        column: x => x.SprintId,
                        principalTable: "Sprint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManagerVersion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    CardJiraId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Major = table.Column<int>(type: "INTEGER", nullable: false),
                    Minor = table.Column<int>(type: "INTEGER", nullable: false),
                    Patch = table.Column<int>(type: "INTEGER", nullable: false),
                    PreRelease = table.Column<int>(type: "INTEGER", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SolutionId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManagerVersion_CardJira_CardJiraId",
                        column: x => x.CardJiraId,
                        principalTable: "CardJira",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManagerVersion_Solution_SolutionId",
                        column: x => x.SolutionId,
                        principalTable: "Solution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardJira_DeveloperId",
                table: "CardJira",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_CardJira_EpicId",
                table: "CardJira",
                column: "EpicId");

            migrationBuilder.CreateIndex(
                name: "IX_CardJira_SprintId",
                table: "CardJira",
                column: "SprintId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerVersion_CardJiraId",
                table: "ManagerVersion",
                column: "CardJiraId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerVersion_SolutionId",
                table: "ManagerVersion",
                column: "SolutionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManagerVersion");

            migrationBuilder.DropTable(
                name: "CardJira");

            migrationBuilder.DropTable(
                name: "Solution");

            migrationBuilder.DropTable(
                name: "Developer");

            migrationBuilder.DropTable(
                name: "EpicFeature");

            migrationBuilder.DropTable(
                name: "Sprint");
        }
    }
}

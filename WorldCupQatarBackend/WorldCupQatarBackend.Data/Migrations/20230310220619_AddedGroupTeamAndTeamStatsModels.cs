using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldCupQatarBackend.Data.Migrations
{
    public partial class AddedGroupTeamAndTeamStatsModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    WorldCupId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => new { x.Id, x.WorldCupId });
                    table.ForeignKey(
                        name: "FK_Groups_WorldCups_WorldCupId",
                        column: x => x.WorldCupId,
                        principalTable: "WorldCups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamsStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchesPlayed = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Draws = table.Column<int>(type: "int", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false),
                    GoalsScored = table.Column<int>(type: "int", nullable: false),
                    GoalsConceded = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamsStats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    WorldCupId = table.Column<int>(type: "int", nullable: false),
                    TeamStatsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Groups_GroupId_WorldCupId",
                        columns: x => new { x.GroupId, x.WorldCupId },
                        principalTable: "Groups",
                        principalColumns: new[] { "Id", "WorldCupId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_TeamsStats_TeamStatsId",
                        column: x => x.TeamStatsId,
                        principalTable: "TeamsStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_WorldCupId",
                table: "Groups",
                column: "WorldCupId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_GroupId_WorldCupId",
                table: "Teams",
                columns: new[] { "GroupId", "WorldCupId" });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_TeamStatsId",
                table: "Teams",
                column: "TeamStatsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "TeamsStats");
        }
    }
}

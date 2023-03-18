using Microsoft.EntityFrameworkCore.Migrations;

namespace WorldCupQatarBackend.Data.Migrations
{
    public partial class AddedDefaultNullValueForBookedMatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Team2Goals",
                table: "Matches",
                type: "int",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Team1Goals",
                table: "Matches",
                type: "int",
                nullable: true,
                defaultValueSql: "NULL",
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Team2Goals",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "NULL");

            migrationBuilder.AlterColumn<int>(
                name: "Team1Goals",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "NULL");
        }
    }
}

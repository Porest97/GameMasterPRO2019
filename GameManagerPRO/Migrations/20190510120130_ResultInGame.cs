using Microsoft.EntityFrameworkCore.Migrations;

namespace GameManagerPRO.Migrations
{
    public partial class ResultInGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AwayTeamScore",
                table: "Game",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeTeamScore",
                table: "Game",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwayTeamScore",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "HomeTeamScore",
                table: "Game");
        }
    }
}

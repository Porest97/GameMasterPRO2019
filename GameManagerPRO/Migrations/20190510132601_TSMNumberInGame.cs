using Microsoft.EntityFrameworkCore.Migrations;

namespace GameManagerPRO.Migrations
{
    public partial class TSMNumberInGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TSMNumber",
                table: "Game",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TSMNumber",
                table: "Game");
        }
    }
}

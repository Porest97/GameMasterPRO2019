using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameManagerPRO.Migrations
{
    public partial class RCTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RefereeCategoryTypeId",
                table: "Person",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RefereeCategoryType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RefereeCategoryTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefereeCategoryType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_RefereeCategoryTypeId",
                table: "Person",
                column: "RefereeCategoryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_RefereeCategoryType_RefereeCategoryTypeId",
                table: "Person",
                column: "RefereeCategoryTypeId",
                principalTable: "RefereeCategoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_RefereeCategoryType_RefereeCategoryTypeId",
                table: "Person");

            migrationBuilder.DropTable(
                name: "RefereeCategoryType");

            migrationBuilder.DropIndex(
                name: "IX_Person_RefereeCategoryTypeId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "RefereeCategoryTypeId",
                table: "Person");
        }
    }
}

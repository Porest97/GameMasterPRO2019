using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameManagerPRO.Migrations
{
    public partial class PROGamedAndTournaments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tournament",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TournamentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PROGame",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MatchNumber = table.Column<int>(nullable: true),
                    MatchDateTime = table.Column<DateTime>(nullable: false),
                    ArenaId = table.Column<int>(nullable: true),
                    TeamId = table.Column<int>(nullable: true),
                    TeamId1 = table.Column<int>(nullable: true),
                    HomeTeamScore = table.Column<int>(nullable: true),
                    AwayTeamScore = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    PersonId1 = table.Column<int>(nullable: true),
                    PersonId2 = table.Column<int>(nullable: true),
                    PersonId3 = table.Column<int>(nullable: true),
                    PersonId4 = table.Column<int>(nullable: true),
                    SeriesId = table.Column<int>(nullable: true),
                    TSMNumber = table.Column<int>(nullable: true),
                    Payment = table.Column<double>(nullable: false),
                    Payed = table.Column<bool>(nullable: false),
                    TournamentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PROGame_Arena_ArenaId",
                        column: x => x.ArenaId,
                        principalTable: "Arena",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROGame_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROGame_Person_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROGame_Person_PersonId2",
                        column: x => x.PersonId2,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROGame_Person_PersonId3",
                        column: x => x.PersonId3,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROGame_Person_PersonId4",
                        column: x => x.PersonId4,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROGame_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROGame_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROGame_Team_TeamId1",
                        column: x => x.TeamId1,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROGame_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PROGame_ArenaId",
                table: "PROGame",
                column: "ArenaId");

            migrationBuilder.CreateIndex(
                name: "IX_PROGame_PersonId",
                table: "PROGame",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PROGame_PersonId1",
                table: "PROGame",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_PROGame_PersonId2",
                table: "PROGame",
                column: "PersonId2");

            migrationBuilder.CreateIndex(
                name: "IX_PROGame_PersonId3",
                table: "PROGame",
                column: "PersonId3");

            migrationBuilder.CreateIndex(
                name: "IX_PROGame_PersonId4",
                table: "PROGame",
                column: "PersonId4");

            migrationBuilder.CreateIndex(
                name: "IX_PROGame_SeriesId",
                table: "PROGame",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_PROGame_TeamId",
                table: "PROGame",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PROGame_TeamId1",
                table: "PROGame",
                column: "TeamId1");

            migrationBuilder.CreateIndex(
                name: "IX_PROGame_TournamentId",
                table: "PROGame",
                column: "TournamentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PROGame");

            migrationBuilder.DropTable(
                name: "Tournament");
        }
    }
}

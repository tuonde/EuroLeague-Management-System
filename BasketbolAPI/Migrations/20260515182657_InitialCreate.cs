using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BasketbolAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Coach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoundedYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomeTeamId = table.Column<int>(type: "int", nullable: false),
                    AwayTeamId = table.Column<int>(type: "int", nullable: false),
                    HomeScore = table.Column<int>(type: "int", nullable: false),
                    AwayScore = table.Column<int>(type: "int", nullable: false),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JerseyNumber = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "City", "Coach", "FoundedYear", "Name" },
                values: new object[,]
                {
                    { 1, "Istanbul", "Jurij Zdovc", 1911, "Galatasaray" },
                    { 2, "Athens", "Ergin Ataman", 1919, "Panathinaikos" },
                    { 3, "Barcelona", "Roger Grimau", 1923, "FC Barcelona" },
                    { 4, "Madrid", "Chus Mateo", 1931, "Real Madrid" },
                    { 5, "Istanbul", "Sarunas Jasikevicius", 1913, "Fenerbahçe Beko" }
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "AwayScore", "AwayTeamId", "HomeScore", "HomeTeamId", "MatchDate" },
                values: new object[,]
                {
                    { 1, 82, 2, 78, 1, new DateTime(2024, 10, 17, 20, 45, 0, 0, DateTimeKind.Utc) },
                    { 2, 76, 1, 91, 2, new DateTime(2025, 1, 3, 19, 15, 0, 0, DateTimeKind.Utc) },
                    { 3, 88, 3, 71, 1, new DateTime(2024, 11, 8, 18, 30, 0, 0, DateTimeKind.Utc) },
                    { 4, 83, 4, 97, 3, new DateTime(2024, 12, 20, 20, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, 90, 4, 86, 2, new DateTime(2025, 2, 6, 20, 30, 0, 0, DateTimeKind.Utc) },
                    { 6, 79, 5, 82, 1, new DateTime(2024, 12, 28, 19, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "FullName", "JerseyNumber", "Position", "TeamId" },
                values: new object[,]
                {
                    { 1, "Sadık Emir Kabaca", 11, "Forvet", 1 },
                    { 2, "David McCormack", 5, "Pivot", 1 },
                    { 3, "James Palmer Jr.", 0, "Şutör gard", 1 },
                    { 4, "Kostas Sloukas", 10, "Oyun kurucu", 2 },
                    { 5, "Mathias Lessort", 26, "Pivot", 2 },
                    { 6, "Juancho Hernangómez", 41, "Forvet", 2 },
                    { 7, "Kostas Antetokounmpo", 37, "Forvet", 2 },
                    { 8, "Nikola Kalinić", 12, "Forvet", 3 },
                    { 9, "Sergio Llull", 23, "Şutör gard", 4 },
                    { 10, "Nigel Hayes-Davis", 11, "Forvet", 5 },
                    { 11, "Nick Calathes", 33, "Oyun kurucu", 5 },
                    { 12, "Tyler Dorsey", 22, "Şutör gard", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayTeamId",
                table: "Matches",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeamId",
                table: "Matches",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviePoster.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    FilmId = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Genre = table.Column<string>(maxLength: 255, nullable: true),
                    AgeLimit = table.Column<string>(maxLength: 255, nullable: true),
                    Duration = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.FilmId);
                });

            migrationBuilder.CreateTable(
                name: "ShowDate",
                columns: table => new
                {
                    ShowDateId = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowDate", x => x.ShowDateId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    FirstName = table.Column<string>(maxLength: 255, nullable: true),
                    LastName = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    ShowDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ShowdateFilm",
                columns: table => new
                {
                    ShowdateFilmId = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    ShowDateId = table.Column<Guid>(nullable: true),
                    FilmId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowdateFilm", x => x.ShowdateFilmId);
                    table.ForeignKey(
                        name: "FK_ShowdateFilm_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowdateFilm_ShowDate_ShowDateId",
                        column: x => x.ShowDateId,
                        principalTable: "ShowDate",
                        principalColumn: "ShowDateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmUsers",
                columns: table => new
                {
                    FilmUserId = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    FilmId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmUsers", x => x.FilmUserId);
                    table.ForeignKey(
                        name: "FK_FilmUsers_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    PlaceId = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    RowNumber = table.Column<int>(nullable: false),
                    SeatNumber = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.PlaceId);
                    table.ForeignKey(
                        name: "FK_Places_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmUsers_FilmId",
                table: "FilmUsers",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmUsers_UserId_FilmId",
                table: "FilmUsers",
                columns: new[] { "UserId", "FilmId" },
                unique: true,
                filter: "[UserId] IS NOT NULL AND [FilmId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Places_UserId",
                table: "Places",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowdateFilm_FilmId",
                table: "ShowdateFilm",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowdateFilm_ShowDateId_FilmId",
                table: "ShowdateFilm",
                columns: new[] { "ShowDateId", "FilmId" },
                unique: true,
                filter: "[ShowDateId] IS NOT NULL AND [FilmId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmUsers");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "ShowdateFilm");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "ShowDate");
        }
    }
}

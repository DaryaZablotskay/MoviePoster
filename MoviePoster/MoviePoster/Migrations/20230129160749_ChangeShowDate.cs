using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviePoster.Migrations
{
    public partial class ChangeShowDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShowdateFilm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShowDate",
                table: "ShowDate");

            migrationBuilder.RenameTable(
                name: "ShowDate",
                newName: "ShowDates");

            migrationBuilder.AddColumn<Guid>(
                name: "FilmId",
                table: "ShowDates",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShowDates",
                table: "ShowDates",
                column: "ShowDateId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowDates_FilmId",
                table: "ShowDates",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowDates_Films_FilmId",
                table: "ShowDates",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "FilmId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowDates_Films_FilmId",
                table: "ShowDates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShowDates",
                table: "ShowDates");

            migrationBuilder.DropIndex(
                name: "IX_ShowDates_FilmId",
                table: "ShowDates");

            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "ShowDates");

            migrationBuilder.RenameTable(
                name: "ShowDates",
                newName: "ShowDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShowDate",
                table: "ShowDate",
                column: "ShowDateId");

            migrationBuilder.CreateTable(
                name: "ShowdateFilm",
                columns: table => new
                {
                    ShowdateFilmId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    FilmId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShowDateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
    }
}

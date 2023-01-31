using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviePoster.Migrations
{
    public partial class AddTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Users_UserId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_ShowDates_Films_FilmId",
                table: "ShowDates");

            migrationBuilder.DropTable(
                name: "FilmUsers");

            migrationBuilder.DropIndex(
                name: "IX_ShowDates_FilmId",
                table: "ShowDates");

            migrationBuilder.DropIndex(
                name: "IX_Places_UserId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "ShowDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "ShowDates");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Places");

            migrationBuilder.AddColumn<int>(
                name: "Hall",
                table: "Places",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Films",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AgeLimit",
                table: "Films",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Films",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    PlaceId = table.Column<Guid>(nullable: true),
                    ShowDateId = table.Column<Guid>(nullable: true),
                    FilmId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Tickets_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_ShowDates_ShowDateId",
                        column: x => x.ShowDateId,
                        principalTable: "ShowDates",
                        principalColumn: "ShowDateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FilmId",
                table: "Tickets",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PlaceId",
                table: "Tickets",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ShowDateId",
                table: "Tickets",
                column: "ShowDateId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId_FilmId_ShowDateId_PlaceId",
                table: "Tickets",
                columns: new[] { "UserId", "FilmId", "ShowDateId", "PlaceId" },
                unique: true,
                filter: "[UserId] IS NOT NULL AND [FilmId] IS NOT NULL AND [ShowDateId] IS NOT NULL AND [PlaceId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropColumn(
                name: "Hall",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Films");

            migrationBuilder.AddColumn<DateTime>(
                name: "ShowDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "FilmId",
                table: "ShowDates",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Places",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "Films",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "AgeLimit",
                table: "Films",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "FilmUsers",
                columns: table => new
                {
                    FilmUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    FilmId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_ShowDates_FilmId",
                table: "ShowDates",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_UserId",
                table: "Places",
                column: "UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Users_UserId",
                table: "Places",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShowDates_Films_FilmId",
                table: "ShowDates",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "FilmId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoMovie.Repository.Migrations
{
    public partial class AddMailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserMail",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MovieOffer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ToMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieOffer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieOffer_Movie_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movie",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MovieOffer_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieRate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", maxLength: 6000, nullable: false),
                    Score = table.Column<byte>(type: "tinyint", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieRate_Movie_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieRate_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieOffer_MoviesId",
                table: "MovieOffer",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieOffer_UserId",
                table: "MovieOffer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRate_MoviesId",
                table: "MovieRate",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRate_UserId",
                table: "MovieRate",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieOffer");

            migrationBuilder.DropTable(
                name: "MovieRate");

            migrationBuilder.DropColumn(
                name: "UserMail",
                table: "User");
        }
    }
}

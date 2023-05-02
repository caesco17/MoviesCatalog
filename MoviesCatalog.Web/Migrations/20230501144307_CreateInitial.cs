using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoviesCatalog.Web.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountRoles",
                columns: table => new
                {
                    AccountRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRoles", x => x.AccountRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    MovieCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.MovieCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_UserAccounts_AccountRoles_AccountRoleId",
                        column: x => x.AccountRoleId,
                        principalTable: "AccountRoles",
                        principalColumn: "AccountRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    MovieCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByAccountId = table.Column<int>(type: "int", nullable: false),
                    Synapsis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_Categories_MovieCategoryId",
                        column: x => x.MovieCategoryId,
                        principalTable: "Categories",
                        principalColumn: "MovieCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_UserAccounts_CreatedByAccountId",
                        column: x => x.CreatedByAccountId,
                        principalTable: "UserAccounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    RatedMovieMovieId = table.Column<int>(type: "int", nullable: true),
                    RatedByAccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Ratings_Movies_RatedMovieMovieId",
                        column: x => x.RatedMovieMovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId");
                    table.ForeignKey(
                        name: "FK_Ratings_UserAccounts_RatedByAccountId",
                        column: x => x.RatedByAccountId,
                        principalTable: "UserAccounts",
                        principalColumn: "AccountId");
                });

            migrationBuilder.InsertData(
                table: "AccountRoles",
                columns: new[] { "AccountRoleId", "Name" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "MovieCategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Comedy" },
                    { 3, "Drama" },
                    { 4, "Fantasy" },
                    { 5, "Horror" }
                });

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "AccountId", "AccountRoleId", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, 1, "user@gmail.com", "User npc", "5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8" },
                    { 2, 2, "admin@gmail.com", "Admin npc", "5E884898DA28047151D0E56F8DC6292773603D0D6AABBDD62A11EF721D1542D8" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "CreatedByAccountId", "CreatedDate", "MovieCategoryId", "Name", "ReleaseYear", "Synapsis" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2023, 5, 1, 8, 43, 7, 75, DateTimeKind.Local).AddTicks(1059), 1, "Goal!", 2006, "Pelicula de deportes." },
                    { 2, 2, new DateTime(2023, 5, 1, 8, 43, 7, 75, DateTimeKind.Local).AddTicks(1069), 2, "El padrino", 1972, "Pelicula de mafiosos." },
                    { 3, 1, new DateTime(2023, 5, 1, 8, 43, 7, 75, DateTimeKind.Local).AddTicks(1070), 3, "Iron Man", 2008, "Pelicula de ciencia ficcion." },
                    { 4, 1, new DateTime(2023, 5, 1, 8, 43, 7, 75, DateTimeKind.Local).AddTicks(1070), 4, "Parásitos", 2019, "Pelicula japonesa." },
                    { 5, 1, new DateTime(2023, 5, 1, 8, 43, 7, 75, DateTimeKind.Local).AddTicks(1071), 5, "Los Cazafantasmas", 1984, "Pelicula Clasica americana" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CreatedByAccountId",
                table: "Movies",
                column: "CreatedByAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieCategoryId",
                table: "Movies",
                column: "MovieCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RatedByAccountId",
                table: "Ratings",
                column: "RatedByAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RatedMovieMovieId",
                table: "Ratings",
                column: "RatedMovieMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccounts_AccountRoleId",
                table: "UserAccounts",
                column: "AccountRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "UserAccounts");

            migrationBuilder.DropTable(
                name: "AccountRoles");
        }
    }
}

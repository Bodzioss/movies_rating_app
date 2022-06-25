using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesRatingApp.API.Migrations
{
    public partial class MovieGenreFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Movies_MovieID",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_TVSeries_SeriesID",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_MovieID",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_SeriesID",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "MovieID",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "SeriesID",
                table: "Genres");

            migrationBuilder.AddColumn<int>(
                name: "SeriesID",
                table: "MovieGenres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_SeriesID",
                table: "MovieGenres",
                column: "SeriesID");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenres_TVSeries_SeriesID",
                table: "MovieGenres",
                column: "SeriesID",
                principalTable: "TVSeries",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_TVSeries_SeriesID",
                table: "MovieGenres");

            migrationBuilder.DropIndex(
                name: "IX_MovieGenres_SeriesID",
                table: "MovieGenres");

            migrationBuilder.DropColumn(
                name: "SeriesID",
                table: "MovieGenres");

            migrationBuilder.AddColumn<int>(
                name: "MovieID",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeriesID",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_MovieID",
                table: "Genres",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_SeriesID",
                table: "Genres",
                column: "SeriesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Movies_MovieID",
                table: "Genres",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_TVSeries_SeriesID",
                table: "Genres",
                column: "SeriesID",
                principalTable: "TVSeries",
                principalColumn: "ID");
        }
    }
}

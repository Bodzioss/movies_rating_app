using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesRatingApp.API.Migrations
{
    public partial class AddRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenreID",
                table: "TVSeries");

            migrationBuilder.DropColumn(
                name: "DirectorID",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "GenreID",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "People",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "SeriesID",
                table: "MoviePeople",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieID = table.Column<int>(type: "int", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenre", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Genres_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_SeriesID",
                table: "Seasons",
                column: "SeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_People_RoleID",
                table: "People",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_MoviePeople_MovieID",
                table: "MoviePeople",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_MoviePeople_PersonID",
                table: "MoviePeople",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_MoviePeople_SeriesID",
                table: "MoviePeople",
                column: "SeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_MovieID",
                table: "Genres",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_SeriesID",
                table: "Genres",
                column: "SeriesID");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_SeasonID",
                table: "Episodes",
                column: "SeasonID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_GenreID",
                table: "MovieGenre",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_MovieID",
                table: "MovieGenre",
                column: "MovieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_Seasons_SeasonID",
                table: "Episodes",
                column: "SeasonID",
                principalTable: "Seasons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_MoviePeople_Movies_MovieID",
                table: "MoviePeople",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoviePeople_People_PersonID",
                table: "MoviePeople",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoviePeople_TVSeries_SeriesID",
                table: "MoviePeople",
                column: "SeriesID",
                principalTable: "TVSeries",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Roles_RoleID",
                table: "People",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_TVSeries_SeriesID",
                table: "Seasons",
                column: "SeriesID",
                principalTable: "TVSeries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_Seasons_SeasonID",
                table: "Episodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Movies_MovieID",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_TVSeries_SeriesID",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviePeople_Movies_MovieID",
                table: "MoviePeople");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviePeople_People_PersonID",
                table: "MoviePeople");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviePeople_TVSeries_SeriesID",
                table: "MoviePeople");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Roles_RoleID",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_TVSeries_SeriesID",
                table: "Seasons");

            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.DropIndex(
                name: "IX_Seasons_SeriesID",
                table: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_People_RoleID",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_MoviePeople_MovieID",
                table: "MoviePeople");

            migrationBuilder.DropIndex(
                name: "IX_MoviePeople_PersonID",
                table: "MoviePeople");

            migrationBuilder.DropIndex(
                name: "IX_MoviePeople_SeriesID",
                table: "MoviePeople");

            migrationBuilder.DropIndex(
                name: "IX_Genres_MovieID",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_SeriesID",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Episodes_SeasonID",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "SeriesID",
                table: "MoviePeople");

            migrationBuilder.DropColumn(
                name: "MovieID",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "SeriesID",
                table: "Genres");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "People",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "GenreID",
                table: "TVSeries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DirectorID",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GenreID",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

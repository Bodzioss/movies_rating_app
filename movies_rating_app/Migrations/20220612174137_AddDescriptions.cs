using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesRatingApp.API.Migrations
{
    public partial class AddDescriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TVSeries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TVSeries");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Movies");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesRatingApp.API.Migrations
{
    public partial class updateRole1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_People_RoleID",
                table: "People",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Roles_RoleID",
                table: "People",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Roles_RoleID",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_RoleID",
                table: "People");
        }
    }
}

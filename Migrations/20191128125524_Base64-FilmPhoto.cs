using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaWebApplication.Migrations
{
    public partial class Base64FilmPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Films",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Films");
        }
    }
}

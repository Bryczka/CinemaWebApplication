using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaWebApplication.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Halls_HallId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Filmshows_FilmshowId",
                table: "Tickets");

            migrationBuilder.AlterColumn<Guid>(
                name: "FilmshowId",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Tickets",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "HallId",
                table: "Seats",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Halls_HallId",
                table: "Seats",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "HallId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Filmshows_FilmshowId",
                table: "Tickets",
                column: "FilmshowId",
                principalTable: "Filmshows",
                principalColumn: "FilmshowId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Halls_HallId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Filmshows_FilmshowId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Tickets");

            migrationBuilder.AlterColumn<Guid>(
                name: "FilmshowId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "HallId",
                table: "Seats",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Halls_HallId",
                table: "Seats",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "HallId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Filmshows_FilmshowId",
                table: "Tickets",
                column: "FilmshowId",
                principalTable: "Filmshows",
                principalColumn: "FilmshowId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaWebApplication.Migrations
{
    public partial class Testfixbug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmshows_Films_FilmId",
                table: "Filmshows");

            migrationBuilder.DropForeignKey(
                name: "FK_Filmshows_Halls_HallId",
                table: "Filmshows");

            migrationBuilder.AlterColumn<Guid>(
                name: "HallId",
                table: "Filmshows",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FilmId",
                table: "Filmshows",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Filmshows_Films_FilmId",
                table: "Filmshows",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "FilmId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filmshows_Halls_HallId",
                table: "Filmshows",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "HallId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmshows_Films_FilmId",
                table: "Filmshows");

            migrationBuilder.DropForeignKey(
                name: "FK_Filmshows_Halls_HallId",
                table: "Filmshows");

            migrationBuilder.AlterColumn<Guid>(
                name: "HallId",
                table: "Filmshows",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "FilmId",
                table: "Filmshows",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Filmshows_Films_FilmId",
                table: "Filmshows",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "FilmId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Filmshows_Halls_HallId",
                table: "Filmshows",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "HallId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

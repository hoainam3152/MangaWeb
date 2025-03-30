using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangaAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableManga_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnglisgTitle",
                table: "Manga",
                newName: "AlternateTitle");

            migrationBuilder.AlterColumn<string>(
                name: "ReleaseDate",
                table: "Manga",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AlternateTitle",
                table: "Manga",
                newName: "EnglisgTitle");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReleaseDate",
                table: "Manga",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);
        }
    }
}

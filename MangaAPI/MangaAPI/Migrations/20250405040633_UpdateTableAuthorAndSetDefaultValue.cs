using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangaAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableAuthorAndSetDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReleaseDate",
                table: "Manga",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                defaultValue: "Đang Cập Nhật",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Manga",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Đang Cập Nhật",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AlternateTitle",
                table: "Manga",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                defaultValue: "Đang Cập Nhật",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BirthDate",
                table: "Author",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Đang Cập Nhật",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "Author",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Đang Cập Nhật",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReleaseDate",
                table: "Manga",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true,
                oldDefaultValue: "Đang Cập Nhật");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Manga",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Đang Cập Nhật");

            migrationBuilder.AlterColumn<string>(
                name: "AlternateTitle",
                table: "Manga",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true,
                oldDefaultValue: "Đang Cập Nhật");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Author",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Đang Cập Nhật");

            migrationBuilder.AlterColumn<string>(
                name: "Biography",
                table: "Author",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Đang Cập Nhật");
        }
    }
}

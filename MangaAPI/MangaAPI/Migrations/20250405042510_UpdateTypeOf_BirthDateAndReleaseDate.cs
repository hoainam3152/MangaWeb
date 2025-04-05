using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MangaAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTypeOf_BirthDateAndReleaseDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReleaseDate",
                table: "Manga",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                defaultValue: "Đang Cập Nhật",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true,
                oldDefaultValue: "Đang Cập Nhật");

            migrationBuilder.AlterColumn<string>(
                name: "BirthDate",
                table: "Author",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                defaultValue: "Đang Cập Nhật",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "Đang Cập Nhật");
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
                defaultValue: "Đang Cập Nhật",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldDefaultValue: "Đang Cập Nhật");

            migrationBuilder.AlterColumn<string>(
                name: "BirthDate",
                table: "Author",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "Đang Cập Nhật",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldDefaultValue: "Đang Cập Nhật");
        }
    }
}

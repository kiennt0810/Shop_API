using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_API.Migrations
{
    /// <inheritdoc />
    public partial class update20240503_v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "PRO_FileImg");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "PRO_FileImg");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "PRO_FileImg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "PRO_FileImg",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "PRO_FileImg",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "PRO_FileImg",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

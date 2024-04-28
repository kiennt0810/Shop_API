using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_API.Migrations
{
    /// <inheritdoc />
    public partial class updatedb20240425 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DungLuong",
                table: "PRO_Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaMau",
                table: "PRO_Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThuongHieu",
                table: "PRO_Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DungLuong",
                table: "PRO_Product");

            migrationBuilder.DropColumn(
                name: "MaMau",
                table: "PRO_Product");

            migrationBuilder.DropColumn(
                name: "ThuongHieu",
                table: "PRO_Product");
        }
    }
}

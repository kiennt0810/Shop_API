using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_API.Migrations
{
    /// <inheritdoc />
    public partial class updatedb20240417 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "TrangThai",
                table: "Pro_Storage",
                type: "bit",
                maxLength: 2,
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TrangThai",
                table: "Pro_Storage",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldMaxLength: 2);
        }
    }
}

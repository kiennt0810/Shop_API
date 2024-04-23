using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_API.Migrations
{
    /// <inheritdoc />
    public partial class updateDb20240411 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StorageCapacities",
                table: "StorageCapacities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Color",
                table: "Color");

            migrationBuilder.RenameTable(
                name: "StorageCapacities",
                newName: "Pro_Storage");

            migrationBuilder.RenameTable(
                name: "Color",
                newName: "Pro_Color");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pro_Storage",
                table: "Pro_Storage",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pro_Color",
                table: "Pro_Color",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pro_Storage",
                table: "Pro_Storage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pro_Color",
                table: "Pro_Color");

            migrationBuilder.RenameTable(
                name: "Pro_Storage",
                newName: "StorageCapacities");

            migrationBuilder.RenameTable(
                name: "Pro_Color",
                newName: "Color");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StorageCapacities",
                table: "StorageCapacities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Color",
                table: "Color",
                column: "Id");
        }
    }
}

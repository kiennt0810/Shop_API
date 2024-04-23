using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_API.Migrations
{
    /// <inheritdoc />
    public partial class updatedb20240422 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRO_Product",
                columns: table => new
                {
                    IdBrand = table.Column<int>(type: "int", maxLength: 128, nullable: false),
                    IdColor = table.Column<int>(type: "int", nullable: false),
                    IdStorage = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaThanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRO_Product_Pro_Brand_IdBrand",
                        column: x => x.IdBrand,
                        principalTable: "Pro_Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRO_Product_Pro_Color_IdColor",
                        column: x => x.IdColor,
                        principalTable: "Pro_Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRO_Product_Pro_Storage_IdStorage",
                        column: x => x.IdStorage,
                        principalTable: "Pro_Storage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_IdBrand",
                table: "PRO_Product",
                column: "IdBrand");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_IdColor",
                table: "PRO_Product",
                column: "IdColor");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_Product_IdStorage",
                table: "PRO_Product",
                column: "IdStorage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRO_Product");
        }
    }
}

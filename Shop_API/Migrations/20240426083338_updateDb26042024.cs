using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_API.Migrations
{
    /// <inheritdoc />
    public partial class updateDb26042024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRO_Customer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<bool>(type: "bit", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_Customer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRO_OrderHdr",
                columns: table => new
                {
                    IdCustomer = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TongTien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HinhThuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_OrderHdr", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRO_OrderHdr_PRO_Customer_IdCustomer",
                        column: x => x.IdCustomer,
                        principalTable: "PRO_Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRO_OrderDtl",
                columns: table => new
                {
                    IdOrderHdr = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoTien = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRO_OrderDtl", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRO_OrderDtl_PRO_OrderHdr_IdOrderHdr",
                        column: x => x.IdOrderHdr,
                        principalTable: "PRO_OrderHdr",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRO_OrderDtl_PRO_Product_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "PRO_Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRO_OrderDtl_IdOrderHdr",
                table: "PRO_OrderDtl",
                column: "IdOrderHdr");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_OrderDtl_IdProduct",
                table: "PRO_OrderDtl",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_PRO_OrderHdr_IdCustomer",
                table: "PRO_OrderHdr",
                column: "IdCustomer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRO_OrderDtl");

            migrationBuilder.DropTable(
                name: "PRO_OrderHdr");

            migrationBuilder.DropTable(
                name: "PRO_Customer");
        }
    }
}

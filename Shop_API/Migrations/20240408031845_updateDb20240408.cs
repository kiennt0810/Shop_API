using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_API.Migrations
{
    /// <inheritdoc />
    public partial class updateDb20240408 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Function",
                columns: table => new
                {
                    MaCN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MaMenu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Function", x => x.MaCN);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    IdNhom = table.Column<int>(type: "int", nullable: false),
                    IdCn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Role_Function_IdCn",
                        column: x => x.IdCn,
                        principalTable: "Function",
                        principalColumn: "MaCN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Role_Group_IdNhom",
                        column: x => x.IdNhom,
                        principalTable: "Group",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Role_IdCn",
                table: "Role",
                column: "IdCn");

            migrationBuilder.CreateIndex(
                name: "IX_Role_IdNhom",
                table: "Role",
                column: "IdNhom");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Function");
        }
    }
}

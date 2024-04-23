using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_API.Migrations
{
    /// <inheritdoc />
    public partial class updateDb20240405 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Staffs",
                table: "Staffs");

            migrationBuilder.RenameTable(
                name: "Staffs",
                newName: "Staff");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staff",
                table: "Staff",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GroupStaff",
                columns: table => new
                {
                    IdNhanVien = table.Column<int>(type: "int", maxLength: 128, nullable: false),
                    IdNhom = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupStaff", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GroupStaff_Group_IdNhom",
                        column: x => x.IdNhom,
                        principalTable: "Group",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupStaff_Staff_IdNhanVien",
                        column: x => x.IdNhanVien,
                        principalTable: "Staff",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupStaff_IdNhanVien",
                table: "GroupStaff",
                column: "IdNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_GroupStaff_IdNhom",
                table: "GroupStaff",
                column: "IdNhom");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupStaff");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staff",
                table: "Staff");

            migrationBuilder.RenameTable(
                name: "Staff",
                newName: "Staffs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staffs",
                table: "Staffs",
                column: "ID");
        }
    }
}

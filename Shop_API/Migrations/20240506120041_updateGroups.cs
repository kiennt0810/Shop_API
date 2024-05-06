using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_API.Migrations
{
    /// <inheritdoc />
    public partial class updateGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SYS_GroupStaff_SYS_Group_IdNhom",
                table: "SYS_GroupStaff");

            migrationBuilder.DropForeignKey(
                name: "FK_SYS_Role_SYS_Group_IdNhom",
                table: "SYS_Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SYS_Group",
                table: "SYS_Group");

            migrationBuilder.RenameTable(
                name: "SYS_Group",
                newName: "SYS_Groups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SYS_Groups",
                table: "SYS_Groups",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SYS_GroupStaff_SYS_Groups_IdNhom",
                table: "SYS_GroupStaff",
                column: "IdNhom",
                principalTable: "SYS_Groups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SYS_Role_SYS_Groups_IdNhom",
                table: "SYS_Role",
                column: "IdNhom",
                principalTable: "SYS_Groups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SYS_GroupStaff_SYS_Groups_IdNhom",
                table: "SYS_GroupStaff");

            migrationBuilder.DropForeignKey(
                name: "FK_SYS_Role_SYS_Groups_IdNhom",
                table: "SYS_Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SYS_Groups",
                table: "SYS_Groups");

            migrationBuilder.RenameTable(
                name: "SYS_Groups",
                newName: "SYS_Group");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SYS_Group",
                table: "SYS_Group",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_SYS_GroupStaff_SYS_Group_IdNhom",
                table: "SYS_GroupStaff",
                column: "IdNhom",
                principalTable: "SYS_Group",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SYS_Role_SYS_Group_IdNhom",
                table: "SYS_Role",
                column: "IdNhom",
                principalTable: "SYS_Group",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
